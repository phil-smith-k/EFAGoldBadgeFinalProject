using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeClasses
{
    public class Menu
    {
        protected readonly List<Meal> _menu = new List<Meal>();
        public bool AddMeal(Meal meal)
        {
            int initialCount = _menu.Count;
            this._menu.Add(meal);

            if (initialCount == _menu.Count - 1)
                return true;
            else
                return false;
        }
        public Meal GetMealByNumber(int num)
        {
            return this._menu.Where(c => c.Number == num).First();
        }
        public Meal GetMealByName(string name)
        {
            return this._menu.Where(c => c.Name.ToLower() == name.ToLower()).First();
        }
        public List<Meal> GetAllMeals()
        {
            return _menu;
        }
        public void UpdateMealByName(string name, Meal newMeal)
        {
            Meal oldMeal = this.GetMealByName(name);

            oldMeal.Number = newMeal.Number;
            oldMeal.Name = newMeal.Name;
            oldMeal.Price = newMeal.Price;
            oldMeal.Description = newMeal.Description;
            oldMeal.Ingredients = newMeal.Ingredients;
        }
        public bool DeleteMealByNumber(int num)
        {
            int initialCount = _menu.Count;
            Meal meal = _menu.Single(c => c.Number == num);
            _menu.Remove(meal);

            if (initialCount == _menu.Count + 1)
                return true;
            else
                return false;
        }
        public bool DeleteMealByName(string name)
        {
            int initialCount = _menu.Count;
            Meal meal = _menu.Single(c => c.Name.ToLower() == name.ToLower());
            _menu.Remove(meal);

            if (initialCount == _menu.Count + 1)
                return true;
            else
                return false;
        }
    }
}
