using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenCarClasses
{
    public class HybridCar : ICar
    {
        public HybridCar() { }
        public HybridCar(string make, string model, int year, int milesPerGallon)
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
            this.MilesPerGallon = milesPerGallon;
        }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int MilesPerGallon { get; set; }
    }
    public class GasCar : ICar
    {
        public GasCar() { }
        public GasCar(string make, string model, int year, int milesPerGallon)
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
            this.MilesPerGallon = milesPerGallon;
        }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int MilesPerGallon { get; set; }
    }
    public class ElectricCar : ICar
    {
        public ElectricCar() { }
        public ElectricCar(string make, string model, int year, int milesPerGallon)
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
            this.MilesPerGallon = milesPerGallon;
        }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int MilesPerGallon { get; set; }
    }
}
