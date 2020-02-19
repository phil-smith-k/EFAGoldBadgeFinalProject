using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutingsUI
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
                    "1) Display All Outings\n" +
                    "2) Add an Outing\n" +
                    "3) See Totals\n");
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
                    default:
                        continue;
                }
            }
        }
        public ConsoleKeyInfo PromptUserForTotalOption()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("What would you like to view?\n" +
                    "1) Total Cost of All Outings\n" +
                    "2) Total Cost of Golf Outings\n" +
                    "3) Total Cost of Amusement Park Outings\n" +
                    "4) Total Cost of Concert Outings\n" +
                    "5) Total Cost of Bowling Outings\n");
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
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        return userInput;
                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        return userInput;
                    default:
                        continue;
                } 
            }
        }
        public DateTime PromptUserForDate()
        {
            Console.Clear();
            Console.WriteLine("Enter the date of the outing:");
            Console.WriteLine("Please enter in this format: DD/MM/YYYY");
            int day = 0;
            int month = 0;
            int year = 0;

            bool didUserEnterDate = true;
            while (didUserEnterDate)
            {
                string[] userInput = Console.ReadLine().Split('/');
                if (userInput.Length == 3 && userInput[0].Length == 2 && userInput[1].Length == 2 && userInput[2].Length == 4)
                {
                    if (int.TryParse(userInput[0], out month))
                    {
                        if (int.TryParse(userInput[1], out day))
                        {
                            if (int.TryParse(userInput[2], out year))
                            {
                                didUserEnterDate = false;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Please enter date in correct format:");
                                continue;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Please enter date in correct format:");
                            continue;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter date in correct format:");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter date in correct format:");
                }
            }
            return new DateTime(year, month, day);
        }
        public int PromptUserForNumberAttended()
        {
            Console.Clear();
            Console.WriteLine("Please enter total number of attendees:");
            int numberAttended = 0;
            bool didUserEnterNumber = true;

            while (didUserEnterNumber)
            {
                string userInput = Console.ReadLine();
                if (int.TryParse(userInput, out numberAttended))
                {
                    didUserEnterNumber = false;
                }
                else
                {
                    Console.WriteLine("Please enter a valid number");
                } 
            }
            return numberAttended;
        }
        public decimal PromptUserForCostPerPerson()
        {
            Console.Clear();
            bool didUserEnterPrice = true;
            decimal numberInput = 0;
            while (didUserEnterPrice)
            {
                Console.WriteLine("Enter Cost Per Person: ");
                Console.WriteLine("Example: $300.00");
                NumberStyles style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol | NumberStyles.AllowDecimalPoint;
                CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");

                string userNumberInput = Console.ReadLine();

                bool isValidNumber = decimal.TryParse(userNumberInput, style, culture, out numberInput);
                if (isValidNumber)
                {
                    didUserEnterPrice = false;
                }
                else
                {
                    Console.WriteLine("Please Enter a Valid Price");
                }
            }
            return numberInput;
        }
        public decimal PromptUserForTotalCost()
        {
            Console.Clear();
            bool didUserEnterPrice = true;
            decimal numberInput = 0;
            while (didUserEnterPrice)
            {
                Console.WriteLine("Enter Total Cost of the Outing: ");
                Console.WriteLine("Example: $1000.00");
                NumberStyles style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol | NumberStyles.AllowDecimalPoint;
                CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");

                string userNumberInput = Console.ReadLine();

                bool isValidNumber = decimal.TryParse(userNumberInput, style, culture, out numberInput);
                if (isValidNumber)
                {
                    didUserEnterPrice = false;
                }
                else
                {
                    Console.WriteLine("Please Enter a Valid Price");
                }
            }
            return numberInput;
        }
        public ConsoleKeyInfo PromptUserForTypeOfOuting()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("What type of outing is this?\n" +
                    "1) Golf\n" +
                    "2) Amusement Park\n" +
                    "3) Concert\n" +
                    "4) Bowling\n");

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
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        return userInput;
                    default:
                        continue;
                }
            }
        }
    }
}
