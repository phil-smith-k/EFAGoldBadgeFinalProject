using GreenCarClasses;
using System;

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
            ConsoleKeyInfo userInput = _prompt.PromptUserForMenuOption();
            switch (userInput.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    DisplayAllCars();
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    DisplayCar();
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
                    break;
            }
        }
        private void DisplayAllCars()
        {
            
        }
        private void DisplayCar()
        {
            throw new NotImplementedException();
        }
        private void AddACar()
        {
            throw new NotImplementedException();
        }
        private void DeleteACar()
        {
            throw new NotImplementedException();
        }
        private void UpdateACar()
        {
            throw new NotImplementedException();
        }
    }
}