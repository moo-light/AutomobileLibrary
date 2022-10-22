using AutomobileLibrary.BusinessObject;
using AutomobileLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileLibrary.Repository
{
    public class CarRepository : ICarRepository
    {
        public IEnumerable<Car> GetCars() => CarDBContext.Instance.GetCarList;

        public Car GetCarByID(int carID)
        => CarDBContext.Instance.GetCarByID(carID);

        public void InsertCar(Car car)
         => CarDBContext.Instance.AddNew(car);

        public void DeleteCar(int carID)
        => CarDBContext.Instance.Remove(carID);

        public void UpdateCar(Car car)
        => CarDBContext.Instance.Update(car);

        
    }
}
