using BadgeClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadgeUI
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
                    "1) Add a Badge\n" +
                    "2) Edit a Badge\n" +
                    "3) List all Badges\n");
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
        public List<Door> PromptUserForDoors()
        {
            Console.Clear();
            List<Door> doors = new List<Door>();

            bool isUserAddingDoors = true;
            while (isUserAddingDoors)
            {
                Console.WriteLine("Add door? (Y/N)\n");
                ConsoleKeyInfo userInput = Console.ReadKey();
                Console.Clear();
                switch (userInput.Key)
                {
                    case ConsoleKey.Y:
                        Console.WriteLine("Enter Door Name:");
                        string name = Console.ReadLine();
                        doors.Add(new Door(name));
                        break;
                    case ConsoleKey.N:
                        isUserAddingDoors = false;
                        break;
                    default:
                        continue;
                }
            }
            return doors;
        }
        public ConsoleKeyInfo PromptUserForEditOption()
        {
            while (true)
            {
                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("1) Add a Badge\n" +
                    "2) Remove a Badge\n");
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
    }
}
