using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenCarClasses
{
    public class CarRepository
    {
        private List<ICar> _carDirectory = new List<ICar>();
        public bool AddCar(ICar car)
        {
            int initialCount = _carDirectory.Count;
            _carDirectory.Add(car);
            return initialCount + 1 == _carDirectory.Count;
        }
        public List<ICar> GetAllCars()
        {
            return _carDirectory;
        }
        public List<ICar> GetAllElectricCars()
        {
            return _carDirectory.Where(c => c is ElectricCar).ToList();
        }
        public List<ICar> GetAllGasCars()
        {
            return _carDirectory.Where(c => c is GasCar).ToList();
        }
        public List<ICar> GetAllHybridCars()
        {
            return _carDirectory.Where(c => c is HybridCar).ToList();
        }
        public ICar GetCarByMakeAndModel(string make, string model)
        {
            return _carDirectory.FirstOrDefault(c => c.Make == make && c.Model == model);
        }
        public bool UpdateCarMilesPerGallon(string make, string model, int newMilesPerGallon)
        {
            ICar car = _carDirectory.FirstOrDefault(c => c.Make == make && c.Model == model);
            if (car != null)
            {
                car.MilesPerGallon = newMilesPerGallon;
                return true;
            }
            return false;
        }
        public bool UpdateCarYear(string make, string model, int newYear)
        {
            ICar car = _carDirectory.FirstOrDefault(c => c.Make == make && c.Model == model);
            if (car != null)
            {
                car.Year = newYear;
                return true;
            }
            return false;
        }
        public bool UpdateCarMake(string make, string model, string newMake)
        {
            ICar car = _carDirectory.FirstOrDefault(c => c.Make == make && c.Model == model);
            if (car != null)
            {
                car.Make = newMake;
                return true;
            }
            return false;
        }
        public bool UpdateCarModel(string make, string model, string newModel)
        {
            ICar car = _carDirectory.FirstOrDefault(c => c.Make == make && c.Model == model);
            if (car != null)
            {
                car.Model = newModel;
                return true;
            }
            return false;
        }
        public bool RemoveCar(string make, string model)
        {
            int initialCount = _carDirectory.Count;
            ICar car = _carDirectory.FirstOrDefault(c => c.Make == make && c.Model == model);

            if (car != null)
            {
                _carDirectory.Remove(car);
            }
            return initialCount - 1 == _carDirectory.Count;
        }
    }
}
