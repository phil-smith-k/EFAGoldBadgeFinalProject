using CafeClasses;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe
{
    class ProgramUI
    {
        private Menu _menu = new Menu();
        private UserPrompt _prompt = new UserPrompt();
        public void Run()
        {
            SeedMenu();
            WelcomeUser();
            DisplayMenu();
        }
        private void WelcomeUser()
        {
            Console.WriteLine("Welcome to the Menu Manager for Komodo Cafe!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
        private void DisplayMenu()
        {
            bool isUserUsingApp = true;
            while (isUserUsingApp)
            {
                Console.Clear();
                Console.WriteLine("What would you like to do today? Please select a number...\n");
                Console.WriteLine("1) Add Meal to Menu\n" +
                    "2) Delete Meal from Menu\n" +
                    "3) Display All Meals\n" +
                    "4) Exit");

                ConsoleKeyInfo userInput = Console.ReadKey();
                switch (userInput.Key)
                {
                    case ConsoleKey.D1:
                        AddAMealToMenu();
                        break;
                    case ConsoleKey.NumPad1:
                        AddAMealToMenu();
                        break;
                    case ConsoleKey.D2:
                        DeleteMenuItem();
                        break;
                    case ConsoleKey.NumPad2:
                        DeleteMenuItem();
                        break;
                    case ConsoleKey.D3:
                        DisplayAllMeals();
                        break;
                    case ConsoleKey.NumPad3:
                        DisplayAllMeals();
                        break;
                    case ConsoleKey.D4:
                        Console.Clear();
                        isUserUsingApp = false;
                        break;
                    case ConsoleKey.NumPad4:
                        Console.Clear();
                        isUserUsingApp = false;
                        break;
                    default:
                        break;
                } 
            }
        }
        private void DeleteMenuItem()
        {
            
        }
        private void AddAMealToMenu()
        {
            Meal meal = new Meal();
            DisplayMealsWithoutIngredients();
            Console.WriteLine();

            Console.WriteLine("Let's Create a Meal!");
            meal.Number = _prompt.PromptUserForMealNumber();
            meal.Name = _prompt.PromptUserForMealName();
            meal.Price = _prompt.PromptUserForMealPrice();
            meal.Description = _prompt.PromptUserForMealDescription();
            meal.Ingredients = _prompt.PromptUserForListOfIngredients();

            _menu.AddMeal(meal);
        }
        private void DisplayAllMeals()
        {
            Console.Clear();
            List<Meal> menu = _menu.GetAllMeals();
            foreach(Meal menuItem in menu)
            {
                Console.WriteLine(menuItem);
                Console.WriteLine("Ingredients:");
                menuItem.Ingredients.ForEach(c => Console.WriteLine(c));
                Console.WriteLine();
            }
            Console.ReadLine();
        }
        private void DisplayMealsWithoutIngredients()
        {
            Console.Clear();
            List<Meal> menu = _menu.GetAllMeals();
            foreach (Meal menuItem in menu)
            {
                Console.WriteLine(menuItem);
            }
        }
        private void SeedMenu()
        {
            Meal meal1 = new Meal(1, "Hamburger", 3.25m, "A delicious greasy hamburger", new List<Ingredient>());
            Meal meal2 = new Meal(2, "Taco", 2.50m, "A yummy taco creation", new List<Ingredient>());
            Meal meal3 = new Meal(3, "Salad", 3.50m, "A healthy vegetarian option", new List<Ingredient>());

            meal1.Ingredients.Add(new Ingredient("Bun"));
            meal1.Ingredients.Add(new Ingredient("Beef Patty"));
            meal1.Ingredients.Add(new Ingredient("Ketchup"));

            meal2.Ingredients.Add(new Ingredient("Flour Tortilla"));
            meal2.Ingredients.Add(new Ingredient("Shredded Chicken"));
            meal2.Ingredients.Add(new Ingredient("Salsa"));

            meal3.Ingredients.Add(new Ingredient("Romaine Lettuce"));
            meal3.Ingredients.Add(new Ingredient("Tomato"));
            meal3.Ingredients.Add(new Ingredient("Balsamic Dressing"));

            _menu.AddMeal(meal1);
            _menu.AddMeal(meal2);
            _menu.AddMeal(meal3);
        }
    }
}
