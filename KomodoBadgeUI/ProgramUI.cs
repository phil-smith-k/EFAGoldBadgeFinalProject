using BadgeClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadgeUI
{
    public class ProgramUI
    {
        BadgeRepository _badgeRepo = new BadgeRepository();
        PromptUser _prompt = new PromptUser();
        public void Run()
        {
            SeedData();
            WelcomeUser();
            DisplayMenu();
        }
        private void WelcomeUser()
        {
            Console.WriteLine("***************************");
            Console.WriteLine("WELCOME TO KOMODO BADGE APP");
            Console.WriteLine("***************************");
            Console.WriteLine("Press enter to continue....");
            Console.ReadLine();
        }
        private void DisplayMenu()
        {
            bool isUserUsingApp = true;
            while (isUserUsingApp)
            {
                ConsoleKeyInfo menuInput = _prompt.PromptUserForMenuOption();
                switch (menuInput.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        AddABadge();
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        EditABadge();
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        DisplayAllBadges();
                        break;
                    default:
                        continue;
                }
            }
        }
        private void AddABadge()
        {
            Badge badge = new Badge();
            List<Door> doors = _prompt.PromptUserForDoors();

            badge.AccessibleDoors = doors;
            _badgeRepo.AddBadgeToDirectory(badge);

            Console.Clear();
            Console.WriteLine($"Badge {badge.ID} was successfully added and has access to the following doors:");
            foreach(var item in doors)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\nPress Enter to Return to Menu...");
            Console.ReadKey();
        }
        private void EditABadge()
        {
            Console.Clear();
            Console.WriteLine("Enter badge ID:");
            string id = Console.ReadLine();
            List<Door> doors = _badgeRepo.GetListOfDoorsByID(id);
            Console.WriteLine($"Badge {id} has access to the following doors:");
            Console.WriteLine(DisplayDoors(doors));

            ConsoleKeyInfo userInput = _prompt.PromptUserForEditOption();
            switch (userInput.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    Console.WriteLine("Enter Door Name:");
                    string doorNameAdd = Console.ReadLine();
                    _badgeRepo.AddDoorToList(id, new Door(doorNameAdd));
                    Console.Clear();
                    Console.WriteLine($"{doorNameAdd} was added to Badge {id}");
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    Console.WriteLine("Enter Door Name to Remove:");
                    string doorNameRemove = Console.ReadLine();
                    _badgeRepo.RemoveDoorFromList(id, new Door(doorNameRemove));
                    Console.WriteLine($"{doorNameRemove} was removed from Badge {id}");
                    break;
            }

        }
        private void DisplayAllBadges()
        {
            Console.Clear();
            Console.WriteLine("ID        Accessible Doors\n" +
                "--------------------------");
            Dictionary<string, List<Door>> badges = _badgeRepo.GetAllBadgesAndDoors();
            foreach(var item in badges)
            {
                Console.WriteLine($"{item.Key}    {DisplayDoors(item.Value)}");
            }
            Console.WriteLine("\nPress Enter to Return to the Menu...");
            Console.ReadLine();
        }
        private string DisplayDoors(List<Door> doors)
        {
            string result = "";
            foreach (var door in doors)
            {
                result += door.Name + " ";
            }
            return result;
        }
        private void SeedData()
        {
            List<Door> doors1 = new List<Door>();
            doors1.Add(new Door("A1"));
            doors1.Add(new Door("A2"));
            doors1.Add(new Door("A3"));
            doors1.Add(new Door("A4"));


            List<Door> doors2 = new List<Door>();
            doors2.Add(new Door("B1"));
            doors2.Add(new Door("B2"));
            doors2.Add(new Door("B3"));
            doors2.Add(new Door("B4"));

            List<Door> doors3 = new List<Door>();
            doors3.Add(new Door("A1"));
            doors3.Add(new Door("B6"));

            Badge badge1 = new Badge("123456", doors1);
            Badge badge2 = new Badge("789101", doors2);
            Badge badge3 = new Badge("654321", doors3);

            _badgeRepo.AddBadgeToDirectory(badge1);
            _badgeRepo.AddBadgeToDirectory(badge2);
            _badgeRepo.AddBadgeToDirectory(badge3);
        }
    }
}

