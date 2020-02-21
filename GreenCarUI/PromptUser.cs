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
                    "2) Display Car\n" +
                    "3) Add a Car" +
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
    }
}