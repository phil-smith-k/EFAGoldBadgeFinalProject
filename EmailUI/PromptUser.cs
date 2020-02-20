using EmailClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailUI
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
                    "1) Display All Customers Alphabetically\n" +
                    "2) Add a Customer\n" +
                    "3) Delete a Customer\n" +
                    "4) Update a Customer");
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
                    default:
                        continue;
                }
            }
        }
        public ConsoleKeyInfo PromptUserForSortOption()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose an option...");
                Console.WriteLine("1) Alphabetical List by First Name");
                Console.WriteLine("2) Alphabetical List by Last Name");

                ConsoleKeyInfo userInput = Console.ReadKey();

                switch (userInput.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        return userInput;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        return userInput;
                    default:
                        continue;
                }
            }
        }
        public ConsoleKeyInfo PromptUserForCustomerType()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose Type of Customer...");
                Console.WriteLine("1) Potential Customer");
                Console.WriteLine("2) Past Customer");
                Console.WriteLine("3) Current Customer");

                ConsoleKeyInfo userInput = Console.ReadKey();

                switch (userInput.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        return userInput;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        return userInput;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        return userInput;
                    default:
                        continue;
                }
            }
        }
        public string PromptUserForFirstName()
        {
            Console.WriteLine("What is the customer's first name?");
            return Console.ReadLine();
        }
        public string PromptUserForLastName()
        {
            Console.WriteLine("What is the customer's last name?");
            return Console.ReadLine();
        }
        public bool PromptUserYesOrNo(string message)
        {
            Console.Clear();

            while (true)
            {
                Console.WriteLine(message);
                ConsoleKeyInfo userInput = Console.ReadKey();
                switch (userInput.Key)
                {
                    case ConsoleKey.Y:
                        return true;
                    case ConsoleKey.N:
                        return false;
                    default:
                        continue;
                } 
            }
        }
    }
}
