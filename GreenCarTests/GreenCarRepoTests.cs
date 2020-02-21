using System;
using System.Collections.Generic;
using GreenCarClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GreenCarTests
{
    [TestClass]
    public class GreenCarRepoTests
    {
        CarRepository _testRepo = new CarRepository();

        [TestInitialize]
        public void Arrange()
        {
            ElectricCar electric1 = new ElectricCar("Tesla", "tesla", 2010, 45);
            _testRepo.AddCar(electric1);

            ElectricCar electric2 = new ElectricCar("Chevy", "Volt", 2019, 42);
            _testRepo.AddCar(electric2);

            ElectricCar electric3 = new ElectricCar("Hiii", "Whatup", 2018, 40);
            _testRepo.AddCar(electric3);

            HybridCar hybrid1 = new HybridCar("Toyota", "Prius", 2020, 38);
            _testRepo.AddCar(hybrid1);

            HybridCar hybrid2 = new HybridCar("Honda", "Something-something", 2019, 39);
            _testRepo.AddCar(hybrid2);

            HybridCar hybrid3 = new HybridCar("Ford", "Another Hybrid", 2017, 39);
            _testRepo.AddCar(hybrid3);

            GasCar gasCar1 = new GasCar("Chevy", "Cruze", 2019, 29);
            _testRepo.AddCar(gasCar1);

            GasCar gasCar2 = new GasCar("Ford", "Focus", 2016, 32);
            _testRepo.AddCar(gasCar2);

            GasCar gasCar3 = new GasCar("Audi", "Q5", 2019, 33);
            _testRepo.AddCar(gasCar3);

            GasCar gasCar4 = new GasCar("Mercedes", "C300", 2018, 28);
            _testRepo.AddCar(gasCar4);
        }
        [TestMethod]
        public void AddCarToRepository_ShouldReturnTrue()
        {
            //Arrange
            CarRepository repo = new CarRepository();
            ElectricCar electric = new ElectricCar();
            GasCar gas = new GasCar();
            HybridCar hybrid = new HybridCar();

            //Act
            bool expected1 = repo.AddCar(electric);
            bool expected2 = repo.AddCar(gas);
            bool expected3 = repo.AddCar(hybrid);

            //Assert
            Assert.IsTrue(expected1);
            Assert.IsTrue(expected2);
            Assert.IsTrue(expected3);
        }
        [TestMethod]
        public void GetAllHybridCars_ShouldReturnCorrectCount()
        {
            //Arrange - Test Init
            
            //Act
            List<ICar> cars = _testRepo.GetAllHybridCars();

            //Assert
            Assert.AreEqual(3, cars.Count);
        }
        [TestMethod]
        public void GetAllGasCars_ShouldReturnCorrectCount()
        {
            //Arrange - Test Init

            //Act
            List<ICar> cars = _testRepo.GetAllGasCars();

            //Assert
            Assert.AreEqual(4, cars.Count);
        }
        [TestMethod]
        public void GetAllElectricCars_ShouldReturnCorrectCount()
        {
            //Arrange - Test Init

            //Act
            List<ICar> cars = _testRepo.GetAllElectricCars();

            //Assert
            Assert.AreEqual(3, cars.Count);
        }
        [TestMethod]
        public void GetCarByMakeAndModel_ShouldReturnCorrectCar()
        {
            //Arrange - Test Init

            //Act 
            ICar car = _testRepo.GetCarByMakeAndModel("Ford", "Focus");

            //Assert
            Assert.AreEqual(2016, car.Year);
        }
        [TestMethod]
        public void UpdateCarMilesPerGallon_ShouldReturnTrue()
        {
            //Arrange - Test Init

            //Act 
            bool actual = _testRepo.UpdateCarMilesPerGallon("Ford", "Focus", 123);

            //Assert
            Assert.IsTrue(actual);
        }
        [TestMethod]
        public void UpdateCarYear_ShouldReturnTrue()
        {
            //Arrange - Test Init

            //Act 
            bool actual = _testRepo.UpdateCarYear("Ford", "Focus", 1999);

            //Assert
            Assert.IsTrue(actual);
        }
        [TestMethod]
        public void UpdateCarMake_ShouldReturnTrue()
        {
            //Arrange - Test Init

            //Act 
            bool actual = _testRepo.UpdateCarMake("Ford", "Focus", "Chevy");

            //Assert
            Assert.IsTrue(actual);
        }
        [TestMethod]
        public void UpdateCarModel_ShouldReturnTrue()
        {
            //Arrange - Test Init

            //Act
            bool actual = _testRepo.UpdateCarModel("Chevy", "Volt", "Tesla");

            //Assert
            Assert.IsTrue(actual);

        }
        [TestMethod]
        public void RemoveCar_ShouldReturnTrue()
        {
            //Arrange - Test Init

            //Act
            bool actual = _testRepo.RemoveCar("Ford", "Focus");

            //Assert
            Assert.IsTrue(actual);
        }
    }
}
