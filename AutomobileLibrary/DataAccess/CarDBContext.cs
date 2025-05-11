using AutomobileLibrary.BusinessObject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileLibrary.DataAccess
{
    public class CarDBContext
    {
        private static List<Car> CarList =
            new List<Car>()
            {
                new Car { CarID = 1, CarName = "CRV", Manufacturer = "Honda", Price = 30000, ReleaseYear = 2021 },
                new Car { CarID = 2, CarName = "Ford Focus", Manufacturer = "Form", Price = 15000, ReleaseYear = 2020 }
            };

        //----------------------------------------------------------
        //Using Singleton Pattern
        private static CarDBContext instance = null;
        private static readonly object instanceLock = new object();

        private CarDBContext()
        {
        }

        public static CarDBContext Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CarDBContext();
                    }

                    return instance;
                }
            }
        }

        public List<Car> GetCarList => CarList;

        //--------------------------------------
        public Car GetCarByID(int carID)
        {
            Car car = CarList.SingleOrDefault(pro => pro.CarID == carID);
            return car;
        }

        //-----------------------------------------------------------
        //Add new a car
        public void AddNew(Car car)
        {
            Car pro = GetCarByID(car.CarID);
            if (pro == null)
            {
                CarList.Add(car);
            }
            else
            {
                throw new Exception($"Car {car.CarID} already Exists");
            }
        }

        //Update a car
        public void Update(Car car)
        {
            Car c = GetCarByID(car.CarID);
            if (c != null)
            {
                var index = CarList.IndexOf(c);
                CarList[index] = car;
            }
            else
            {
                throw new Exception($"Car {car.CarID} Not Exists.");
            }
        }

        //-------------------------------------------------
        //Remove a car
        public void Remove(int carID)
        {
            Car p = GetCarByID(carID);
            if (p != null)
            {
                CarList.Remove(p);
            }
            else
            {
                throw new Exception("Car not Exists.");
            }
        }
    } //end class
}