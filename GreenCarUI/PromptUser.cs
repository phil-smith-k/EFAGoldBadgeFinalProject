using GreenCarClasses;
using System;

namespace GreenCarUI
{
    public class PromptUser
    {
        public ConsoleKeyInfo PromptUserForMenuOption()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("********Main Menu**********\n");
                Console.WriteLine("Please select an option....\n\n" +
                    "1) Display All Cars\n" +
                    "2) Display Cars By Type\n" +
                    "3) Add a Car\n" +
                    "4) Delete a Car\n" +
                    "5) Update a Car");
                Console.WriteLine("***************************");
                ConsoleKeyInfo userInput = Console.ReadKey();

                switch (userInput.Key)
                {
                    case ConsoleKey.D1:
                        return userInput;
                    case ConsoleKey.NumPad1:
                        return userInput;
                    case ConsoleKey.D2:
                        return userInput;
                    case ConsoleKey.NumPad2:
                        return userInput;
                    case ConsoleKey.D3:
                        return userInput;
                    case ConsoleKey.NumPad3:
                        return userInput;
                    case ConsoleKey.D4:
                        return userInput;
                    case ConsoleKey.NumPad4:
                        return userInput;
                    case ConsoleKey.D5:
                        return userInput;
                    case ConsoleKey.NumPad5:
                        return userInput;
                    default:
                        continue;
                }
            }
        }
        public ICar PromptUserForType()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("What type?");
                Console.WriteLine("1) Electric\n" +
                    "2) Hybrid\n" +
                    "3) Gas\n");

                ConsoleKeyInfo userInput = Console.ReadKey();

                switch (userInput.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        return new ElectricCar();
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        return new HybridCar();
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        return new GasCar();
                    default:
                        continue;
                } 
            }
        }
        public string PromptUserForMake()
        {
            Console.Clear();
            Console.WriteLine("What is the make of the car?");
            return Console.ReadLine();
        }
        public string PromptUserForModel()
        {
            Console.Clear();
            Console.WriteLine("What is the model of the car?");
            return Console.ReadLine();
        }
        public int PromptUserForYear()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("What is the year of the car?");
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int year) && userInput.Length == 4)
                {
                    return year;
                }
                else
                {
                    continue;
                } 
            }
        }
        public int PromptUserForMilesPerGallon()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("What is the mileage?");
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int mpg))
                {
                    return mpg;
                }
                else
                {
                    continue;
                } 
            }
        }
    }
}