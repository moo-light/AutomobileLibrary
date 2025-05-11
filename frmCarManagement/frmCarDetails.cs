using AutomobileLibrary.BusinessObject;
using AutomobileLibrary.Repository;
using log4net;

namespace AutomobileWinApp
{
    public partial class frmCarDetails : Form
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(frmCarDetails));

        public frmCarDetails()
        {
            InitializeComponent();
        }

        public ICarRepository CarRepositiory { get; set; }
        public bool InsertOrUpdate { get; set; }
        public Car CarInfo { get; set; }

        private Action<Car> ExecuteCreateOrUpdate;


        private void frmCarDetails_Load(object sender, EventArgs e)
        {
            _log.InfoFormat("frmCarDetails_Load");
            cboManufacturer.SelectedIndex = 0;
            txtCarID.Enabled = !InsertOrUpdate;
            _log.InfoFormat("Form Action: {0}", InsertOrUpdate == true ? "Update" : "Insert");
            if (InsertOrUpdate == true)
            {
                txtCarID.Text = CarInfo.CarID.ToString();
                txtCarName.Text = CarInfo.CarName;
                txtPrice.Text = CarInfo.Price.ToString();
                txtReleaseYear.Text = CarInfo.ReleaseYear.ToString();
                cboManufacturer.Text = CarInfo.Manufacturer.Trim();
                ExecuteCreateOrUpdate += CarRepositiory.UpdateCar;
            }
            else
            {
                ExecuteCreateOrUpdate += CarRepositiory.InsertCar;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var car = new Car
                {
                    CarID = int.Parse(txtCarID.Text),
                    CarName = txtCarName.Text,
                    Manufacturer = cboManufacturer.Text,
                    Price = decimal.Parse(txtPrice.Text),
                    ReleaseYear = int.Parse(txtReleaseYear.Text),
                };
                _log.InfoFormat("Saving car details");
                ExecuteCreateOrUpdate(car);
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error {0}: {1}", nameof(btnSave_Click), ex.Message);
                MessageBox.Show(ex.Message, InsertOrUpdate == false ? "Add new car" : "Update car");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) => Close();
    }
}