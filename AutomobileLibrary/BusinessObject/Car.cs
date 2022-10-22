using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileLibrary.BusinessObject
{
    public class Car
    {
        private int carID;
        private string _carName;
        private string _manufacturer;
        private decimal price;
        private int releaseYear;

        public int CarID { get => carID; set => carID = value; }
        public string CarName { get => _carName; set => _carName = value; }
        public string Manufacturer { get => _manufacturer; set => _manufacturer = value; }
        public decimal Price { get => price; set => price = value; }
        public int ReleaseYear { get => releaseYear; set => releaseYear = value; }

    }
}
