using OutingsClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutingsUI
{
    public class ProgramUI
    {
        OutingRepository _outings = new OutingRepository();
        PromptUser _prompt = new PromptUser();
        public void Run()
        {
            SeedOutings();
            WelcomeUser();
            DisplayMenu();
        }
        private void WelcomeUser()
        {
            Console.WriteLine("********************************************");
            Console.WriteLine("Welcome to Komodo Outing Management Software");
            Console.WriteLine("********************************************");
            Console.WriteLine("Press enter to continue...");
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
                        DisplayAllOutings();
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        AddAnOuting();
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        SeeTotals();
                        break;
                    case ConsoleKey.D4:
                    default:
                        continue;
                }
            }

        }
        private void DisplayAllOutings()
        {
            Console.Clear();
            List<IOuting> outings = _outings.GetAllOutings();
            outings.ForEach(o => DisplayOneOuting(o));
            Console.Read();
        }
        private void SeeTotals()
        {
            ConsoleKeyInfo userInput = _prompt.PromptUserForTotalOption();
            switch (userInput.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    Console.Clear();
                    Console.WriteLine($"Total Cost of All Outings: {_outings.GetTotalCostOfAllOutings()}");
                    Console.ReadLine();
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    Console.Clear();
                    Console.WriteLine($"Total Cost of Golf Outings: {_outings.GetTotalCostOfGolfOutings()}");
                    Console.ReadLine();
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    Console.Clear();
                    Console.WriteLine($"Total Cost of Amusement Park Outings: {_outings.GetTotalCostOfAmusementParkOutings()}");
                    Console.ReadLine();
                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    Console.Clear();
                    Console.WriteLine($"Total Cost of Concert Outings: {_outings.GetTotalCostOfConcertOutings()}");
                    Console.ReadLine();
                    break;
                case ConsoleKey.D5:
                case ConsoleKey.NumPad5:
                    Console.Clear();
                    Console.WriteLine($"Total Cost of Bowling Outings: {_outings.GetTotalCostOfBowlingOutings()}");
                    Console.ReadLine();
                    break;
                default:
                    break;
            }
        }
        private void AddAnOuting()
        {
            DateTime date = _prompt.PromptUserForDate();
            int numberAttended = _prompt.PromptUserForNumberAttended();
            decimal costPerPerson = _prompt.PromptUserForCostPerPerson();
            decimal totalCost = _prompt.PromptUserForTotalCost();

            ConsoleKeyInfo userInput = _prompt.PromptUserForTypeOfOuting();

            switch (userInput.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    _outings.AddOuting(new GolfOuting(date, numberAttended, costPerPerson, totalCost));
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    _outings.AddOuting(new AmusementParkOuting(date, numberAttended, costPerPerson, totalCost));
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    _outings.AddOuting(new ConcertOuting(date, numberAttended, costPerPerson, totalCost));
                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    _outings.AddOuting(new BowlingOuting(date, numberAttended, costPerPerson, totalCost));
                    break;
                default:
                    break;
            }
            Console.Clear();
            Console.WriteLine("The outing was successfully added!\n" +
                "Press enter to return to menu...");
            Console.ReadLine();
        }
        private void DisplayOneOuting(IOuting outing)
        {
            Console.WriteLine($"Date: {outing.Date.ToString("MM/dd/yyyy")}\n" +
                $"Type of Outing: {outing.Type}\n" +
                $"Number of People Attended: {outing.NumberAttended}\n" +
                $"Cost Per Person {outing.CostPerPerson:C}\n" +
                $"Total Cost: {outing.TotalCost}\n");
        }
        private void SeedOutings()
        {
            GolfOuting golfOuting1 = new GolfOuting(new DateTime(2019, 9, 1), 20, 25.00m, 1000.00m);
            _outings.AddOuting(golfOuting1);

            GolfOuting golfOuting2 = new GolfOuting(new DateTime(2019, 6, 1), 15, 25.00m, 800.00m);
            _outings.AddOuting(golfOuting2);

            ConcertOuting concertOuting1 = new ConcertOuting(new DateTime(2020, 1, 6), 40, 30.00m, 5000.00m);
            _outings.AddOuting(concertOuting1);

            ConcertOuting concertOuting2 = new ConcertOuting(new DateTime(2019, 2, 2), 10, 15.00m, 600.00m);
            _outings.AddOuting(concertOuting2);

            AmusementParkOuting amusement1 = new AmusementParkOuting(new DateTime(2019, 5, 11), 20, 25.00m, 1000.00m);
            _outings.AddOuting(amusement1);

            AmusementParkOuting amusement2 = new AmusementParkOuting(new DateTime(2019, 7, 7), 50, 40.00m, 8000.00m);
            _outings.AddOuting(amusement2);

            BowlingOuting bowling1 = new BowlingOuting(new DateTime(2019, 3, 3), 50, 5.00m, 800.00m);
            _outings.AddOuting(bowling1);

            BowlingOuting bowling2 = new BowlingOuting(new DateTime(2019, 11, 4), 60, 5.00m, 900.00m);
            _outings.AddOuting(bowling2);
        }
    }
}
