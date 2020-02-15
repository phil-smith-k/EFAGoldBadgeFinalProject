using System;
using System.Collections.Generic;
using CafeClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CafeTest
{
    [TestClass]
    public class MenuTests
    {
        Menu _menu = new Menu();

        List<Ingredient> _ingredients = new List<Ingredient>
        {
            new Ingredient("Bun"),
            new Ingredient("Patty"),
            new Ingredient("Tomato"),
            new Ingredient("Onion")
        };

        private void Arrange()
        {
            
            Meal meal1 = new Meal(1, "CheeseBurger", 2.00m, "A cheeseburger", _ingredients);
            _menu.AddMeal(meal1);

            Meal meal2 = new Meal(2, "Burger", 1.00m, "A burger", _ingredients);
            _menu.AddMeal(meal2);

            Meal meal3 = new Meal(3, "Salad", 3.00m, "A healthy salad", _ingredients);
            _menu.AddMeal(meal3);

            Meal meal4 = new Meal(4, "Chicken Sandwich", 2.00m, "A chicken sandwich", _ingredients);
            _menu.AddMeal(meal4);

            Meal meal5 = new Meal(5, "Taco", 1.50m, "A taco", _ingredients);
            _menu.AddMeal(meal5);
        }
        
        [TestMethod]
        public void AddItemToMenu_ShouldReturnCorrectMealCount()
        {
            Arrange();
            Meal meal = new Meal();

            _menu.AddMeal(meal);

            Assert.IsTrue(_menu.AddMeal(meal));
        }
        [TestMethod]
        public void GetMealByNumber_ShouldReturnCorrectMeal()
        {
            Arrange();
            Meal meal = _menu.GetMealByNumber(2);

            Assert.AreEqual("Burger", meal.Name);
        }
        [TestMethod]
        public void GetMealByName_ShouldReturnCorrectMeal()
        {
            Arrange();
            // Act
            Meal meal =_menu.GetMealByName("Taco");

            // Assert
            Assert.AreEqual("A taco", meal.Description);
        }
        [TestMethod]
        public void GetAllMeals_ShouldReturnListWithCorrectCount()
        {
            Arrange();
            // Act
            List<Meal> meals = _menu.GetAllMeals();
            // Assert
            Assert.AreEqual(5, meals.Count);

        }
        [TestMethod]
        public void UpdateMeal_ShouldReturnAnUpdatePropertyValue()
        {
            Arrange();
            Meal updatedMeal = _menu.GetMealByName("taco");

            Meal newMeal = new Meal(8, "Taco Loco", 3.00m, "A taco loco", _ingredients);
            _menu.UpdateMealByName("Taco", newMeal);

            Assert.AreEqual("Taco Loco", updatedMeal.Name);
            Assert.AreEqual(3.00m, updatedMeal.Price);
            Assert.AreEqual(8, updatedMeal.Number);
            Assert.AreEqual("A taco loco", updatedMeal.Description);
        }
        [TestMethod]
        public void DeleteMealByName_ShouldReturnTrue()
        {
            Arrange();
            //Act
            //Assert
            Assert.IsTrue(_menu.DeleteMealByName("Taco"));
        }
        [TestMethod]
        public void DeleteMealByNumber_ShouldReturnTrue()
        {
            Arrange();
            //Act
            //Assert
            Assert.IsTrue(_menu.DeleteMealByNumber(3));
        }
    }
}
