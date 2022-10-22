using AutomobileLibrary.BusinessObject;
using AutomobileLibrary.Repository;
using AutomobileWinApp;

namespace frmCarManagement
{
    public partial class frmCarManagement : System.Windows.Forms.Form
    {
        ICarRepository carRepository= new CarRepository();
        BindingSource source;
        public frmCarManagement()
        {
            InitializeComponent();
        }

        private void frmCarManagement_Load(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
            dgvCarList.CellDoubleClick += DgvCarList_CellDoubleClick ;
        }
        private void DgvCarList_CellDoubleClick(object sender,EventArgs e)
        {
            frmCarDetails frmCarDetails = new frmCarDetails
            {
                Text = "Update Car",
                InsertOrUpdate = true,
                CarInfo = GetCarObject(),
                CarRepositiory = carRepository
            };
            if(frmCarDetails.ShowDialog() == DialogResult.OK)
            {
                LoadCarList();
                source.Position = source.Count - 1;
            }
        }
        private void ClearText()
        {
            txtCarID.Text = String.Empty;
            txtCarName.Text = String.Empty;
            txtManufacturer.Text = String.Empty;
            txtPrice.Text = String.Empty;
            txtReleaseYear.Text = String.Empty;
        }
        private void LoadCarList()
        {
            var cars = carRepository.GetCars();
            try
            {
                source = new BindingSource();
                source.DataSource = cars;

                txtCarID.DataBindings.Clear();
                txtCarName.DataBindings.Clear();
                txtManufacturer.DataBindings.Clear();
                txtPrice.DataBindings.Clear();
                txtReleaseYear.DataBindings.Clear();

                txtCarID.DataBindings.Add("Text",source,"CarID");
                txtCarName.DataBindings.Add("Text",source,"CarName");
                txtManufacturer.DataBindings.Add("Text",source, "Manufacturer");
                txtPrice.DataBindings.Add("Text",source,"Price");
                txtReleaseYear.DataBindings.Add("Text",source, "ReleaseYear");

                dgvCarList.DataSource = source;
                if(cars.Count()== 0)
                {
                    ClearText();
                    btnDelete.Enabled = false;
                }
                else
                {
                    btnDelete.Enabled = true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Load car list");
            }    
        }
        private Car GetCarObject()
        {
            Car car = null;
            try
            {
                car = new Car
                {
                    CarID = int.Parse(txtCarID.Text),
                    CarName = txtCarName.Text,
                    Manufacturer = txtManufacturer.Text,
                    Price = decimal.Parse(txtPrice.Text),
                    ReleaseYear = int.Parse(txtReleaseYear.Text)
                };
            }catch(Exception e)
            {
                MessageBox.Show(e.Message, "Get Car");
            }
            return car;
        }
        private void btnLoad_Click(object sender, EventArgs e)
        =>
            LoadCarList();

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmCarDetails frmCarDetails = new frmCarDetails
            {
                Text = "Add car",
                InsertOrUpdate = false,
                CarRepositiory = carRepository
            };
            if (frmCarDetails.ShowDialog() == DialogResult.OK)
            {
                LoadCarList();
                //Set focus car inserted
                source.Position = source.Count - 1;
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var car = GetCarObject();
                carRepository.DeleteCar(car.CarID);
                LoadCarList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete a car");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        => Close();
    }
}