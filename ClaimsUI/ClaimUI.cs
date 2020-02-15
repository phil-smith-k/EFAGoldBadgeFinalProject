using ClaimsClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsUI
{
    public class ClaimUI
    {
        ClaimRepository _claims = new ClaimRepository();
        public void Run()
        {
            SeedClaims();
            WelcomeUser();
            DisplayMenu();
        }
        private void WelcomeUser()
        {
            Console.WriteLine("*****************************");
            Console.WriteLine("Welcome to Komodo Claims Tool");
            Console.WriteLine(" Press enter to display menu ");
            Console.WriteLine("*****************************");
            Console.ReadLine();
        }
        private void DisplayMenu()
        {
            bool isUserUsingApp = true;
            while (isUserUsingApp)
            {
                Console.WriteLine("*****************************");
                Console.WriteLine("          Main Menu          ");
                Console.WriteLine("*****************************\n");

                Console.WriteLine("1) See All Claims\n" +
                    "2) Next Claim\n" +
                    "3) Enter A New Claim\n" +
                    "4) Exit Program");

                ConsoleKeyInfo userInput = Console.ReadKey();

                switch (userInput.Key)
                {
                    case ConsoleKey.D1:
                        DisplayAllClaims();
                        break;
                    case ConsoleKey.NumPad1:
                        DisplayAllClaims();
                        break;
                    case ConsoleKey.D2:

                        break;
                    case ConsoleKey.NumPad2:

                        break;
                    case ConsoleKey.D3:

                        break;
                    case ConsoleKey.NumPad3:

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
                        continue;
                } 
            }
        }
        private void DisplayAllClaims()
        {
            Console.Clear();
            List<Claim> claims = new List<Claim>();
            claims = _claims.GetAllClaims();

            foreach(Claim claim in claims)
            {
                Console.WriteLine($"{claim.ID} {claim.TypeOfClaim} {claim.Description} {claim.Amount} {claim.DateOfIncident.ToString("dd/MM/yyyy")} {claim.DateOfClaim.ToString("dd/MM/yyyy")} {claim.IsValid}\n");
            }
            Console.ReadLine();
        }
        private void SeedClaims()
        {
            Claim claim1 = new Claim("123456", ClaimType.Car, "Wreck", 1000m, new DateTime(2020, 1, 1), new DateTime(2020, 1, 7));
            _claims.AddClaimToQueue(claim1);

            Claim claim2 = new Claim("123457", ClaimType.Theft, "Stolen stuff", 2000m, new DateTime(2020, 1, 1), new DateTime(2020, 1, 4));
            _claims.AddClaimToQueue(claim2);

            Claim claim3 = new Claim("123458", ClaimType.Home, "Flooded basement", 5000m, new DateTime(2020, 1, 1), new DateTime(2020, 1, 15));
            _claims.AddClaimToQueue(claim3);

            Claim claim4 = new Claim("123459", ClaimType.Car, "Bad wreck", 6000m, new DateTime(2020, 1, 1), new DateTime(2020, 1, 2));
            _claims.AddClaimToQueue(claim4);
        }
    }
}
