using ClaimsClasses;
using System;
using System.Globalization;

namespace ClaimsUI
{
    public class PromptUser
    {
        public ClaimType PromptUserForTypeOfClaim()
        {
            bool isUserEnteringNumber = true;
            ClaimType claimType = 0;
            while (isUserEnteringNumber)
            {
                Console.Clear();
                Console.WriteLine("Please select a type of claim:\n" +
                    "1) Car\n" +
                    "2) Home\n" +
                    "3) Theft\n");
                ConsoleKeyInfo userInput = Console.ReadKey();
                switch (userInput.Key)
                {
                    case ConsoleKey.D1:
                        claimType = 0;
                        isUserEnteringNumber = false;
                        break;
                    case ConsoleKey.NumPad1:
                        claimType = 0;
                        isUserEnteringNumber = false;
                        break;
                    case ConsoleKey.D2:
                        claimType = (ClaimType)1;
                        isUserEnteringNumber = false;
                        break;
                    case ConsoleKey.NumPad2:
                        claimType = (ClaimType)1;
                        isUserEnteringNumber = false;
                        break;
                    case ConsoleKey.D3:
                        claimType = (ClaimType)2;
                        isUserEnteringNumber = false;
                        break;
                    case ConsoleKey.NumPad3:
                        claimType = (ClaimType)1;
                        isUserEnteringNumber = false;
                        break;
                    default:
                        continue;
                }
            }
            return claimType;
        }
        public string PromptUserForDescription()
        {
            Console.Clear();
            Console.WriteLine("Enter a description of the incident:");
            return Console.ReadLine();
        }
        public decimal PromptUserForAmount()
        {
            Console.Clear();
            bool didUserEnterPrice = true;
            decimal numberInput = 0;
            while (didUserEnterPrice)
            {
                Console.WriteLine("Enter an amount: ");
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
        public DateTime PromptUserForDateOfIncident()
        {
            Console.Clear();
            Console.WriteLine("Enter the date of the incident:");
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
                    if(int.TryParse(userInput[0], out month))
                    {
                        if(int.TryParse(userInput[1], out day))
                        {
                            if(int.TryParse(userInput[2], out year))
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
        public DateTime PromptUserForDateOfClaim()
        {
        Console.Clear();
        Console.WriteLine("Enter the date of the claim:");
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
    }
}