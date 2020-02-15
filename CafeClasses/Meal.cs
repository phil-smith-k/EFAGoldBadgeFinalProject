using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeClasses
{
    public class Meal
    {
        public Meal() { }
        public Meal(int num, string name, decimal price, string description, List<Ingredient> ingredients)
        {
            this.Number = num;
            this.Name = name;
            this.Price = price;
            this.Description = description;
            this.Ingredients = ingredients;
        }
        public int Number { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public void AddIngredientToMeal(Ingredient ingredient)  
        {
            this.Ingredients.Add(ingredient);
        }
        public override string ToString()
        {
            return $"No. {this.Number} {this.Name} {this.Price:C} Description: {this.Description}";
        }
    }

    public class Ingredient
    {
        public Ingredient() { }
        public Ingredient(string name)
        {
            this.Name = name;
        }
        public string Name { get; set; }
        public override string ToString()
        {
            return this.Name;
        }
    }
}
