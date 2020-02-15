using CafeClasses;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe
{
    public class UserPrompt
    {
        public int PromptUserForMealNumber()
        {
            bool didUserEnterNumber = true;
            int numberInput = 0;

            while (didUserEnterNumber)
            {
                Console.WriteLine("Enter a number: ");
                string userNumberInput = Console.ReadLine();

                bool isValidNumber = int.TryParse(userNumberInput, out numberInput);
                if (isValidNumber)
                {
                    didUserEnterNumber = false;
                }
                else
                {
                    Console.WriteLine("Please Enter a Valid Number");
                }
            }
            return numberInput;
        }
        public string PromptUserForMealName()
        {
            Console.Clear();
            Console.WriteLine("Enter a name: ");
            string name = Console.ReadLine();
            return name;
        }
        public decimal PromptUserForMealPrice()
        {
            Console.Clear();
            bool didUserEnterPrice = true;
            decimal numberInput = 0;
            while (didUserEnterPrice)
            {
                Console.WriteLine("Enter a price: ");
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
        public string PromptUserForMealDescription()
        {
            Console.Clear();
            Console.WriteLine("Enter a description:");
            string userDescriptionInput = Console.ReadLine();
            return userDescriptionInput;
        }
        public List<Ingredient> PromptUserForListOfIngredients()
        {
            Console.Clear();

            List<Ingredient> ingredients = new List<Ingredient>();
            bool hasUserFinishedAddingIngredients = true;

            Console.WriteLine("No ingredients yet..." +
                "--------------------------");
            Console.WriteLine("Type Ingredient, Press Enter to Add to Ingredient List...");
            ingredients.Add(new Ingredient(Console.ReadLine()));

            while (hasUserFinishedAddingIngredients)
            {
                Console.Clear();
                Console.WriteLine("Ingredients:");
                ingredients.ForEach(c => Console.WriteLine(c));
                Console.WriteLine("--------------------------");
                Console.WriteLine("Type Ingredient, Press Enter to Add to Ingredient List..." +
                    "Type \"done\" and Press Enter When Finished...");
                string userInput = Console.ReadLine();
                if (userInput == "done")
                    break;
                else
                    ingredients.Add(new Ingredient(userInput));
            }
            return ingredients;
        }

    }
}
