using GreenCarClasses;
using System;
using System.Collections.Generic;

namespace GreenCarUI
{
    public class ProgramUI
    {
        CarRepository _carRepo = new CarRepository();
        PromptUser _prompt = new PromptUser();
        public void Run()
        {
            WelcomeUser();
            DisplayMenu();
        }
        private void WelcomeUser()
        {
            Console.WriteLine("***********************************");
            Console.WriteLine("Welcome to Komodo Green Car Manager");
            Console.WriteLine("***********************************");
            Console.WriteLine("Press enter to continue to menu....");
            Console.ReadLine();
        }
        private void DisplayMenu()
        {
            while (true)
            {
                ConsoleKeyInfo userInput = _prompt.PromptUserForMenuOption();
                switch (userInput.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        DisplayAllCars();
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        DisplayCarsByType();
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        AddACar();
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        DeleteACar();
                        break;
                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        UpdateACar();
                        break;
                    default:
                        continue;
                } 
            }
        }
        private void DisplayAllCars()
        {
            Console.Clear();
            List<ICar> cars = _carRepo.GetAllCars();
            cars.ForEach(car => PrintCar(car));
            Console.ReadLine();
        }
        private void DisplayCarsByType()
        {
            ICar car = _prompt.PromptUserForType();

            if (car is ElectricCar)
            {
                Console.Clear();
                List<ICar> electric = _carRepo.GetAllElectricCars();
                electric.ForEach(c => PrintCar(c));
                Console.ReadLine();
            }
            else if (car is HybridCar)
            {
                Console.Clear();
                List<ICar> hybrid = _carRepo.GetAllHybridCars();
                hybrid.ForEach(c => PrintCar(c));
                Console.ReadLine();
            }
            else
            {
                Console.Clear();
                List<ICar> gas = _carRepo.GetAllGasCars();
                gas.ForEach(c => PrintCar(c));
                Console.ReadLine();
            }
        }
        private void AddACar()
        {
            ICar carToAdd = _prompt.PromptUserForType();
            carToAdd.Make = _prompt.PromptUserForMake();
            carToAdd.Model = _prompt.PromptUserForModel();
            carToAdd.Year = _prompt.PromptUserForYear();
            carToAdd.MilesPerGallon = _prompt.PromptUserForMilesPerGallon();

            _carRepo.AddCar(carToAdd);
        }
        private void DeleteACar()
        {
            string make = _prompt.PromptUserForMake();
            string model = _prompt.PromptUserForModel();

            _carRepo.RemoveCar(make, model);

            Console.Clear();
            Console.WriteLine("The car was successfully removed.");
            Console.WriteLine("Press enter to return to the menu...");
            Console.ReadLine();
        }
        private void UpdateACar()
        {
            string make = _prompt.PromptUserForMake();
            string model = _prompt.PromptUserForModel();

            ICar car = _carRepo.GetCarByMakeAndModel(make, model);

            Console.WriteLine("What is the new mileage?");
            int mileage = _prompt.PromptUserForMilesPerGallon();

            car.MilesPerGallon = mileage;
            Console.WriteLine("The mileage was updated.");
            Console.WriteLine("Press enter to return to menu...");
            Console.ReadLine();
        }
        private void PrintCar(ICar car)
        {
            Console.WriteLine($"{car.Year,-15} {car.Make,-15} {car.Model,-15} {car.MilesPerGallon, -15}");
        }
    }
}