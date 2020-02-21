using EmailClasses;
using System;
using System.Collections.Generic;

namespace EmailUI
{
    public class ProgramUI
    {
        CustomerRepository _customerRepo = new CustomerRepository();
        PromptUser _prompt = new PromptUser();

        public void Run()
        {
            SeedCustomers();
            WelcomeUser();
            DisplayMenu();
        }
        private void WelcomeUser()
        {
            Console.WriteLine("*******************************************");
            Console.WriteLine("Welcome to Komodo Email Management Software");
            Console.WriteLine("*******************************************");
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
                        DisplayAllCustomersAlphabetically();
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        AddACustomer();
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        DeleteACustomer();
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        UpdateACustomer();
                        break;
                    default:
                        continue;
                }
            }
        }
        private void DisplayAllCustomersAlphabetically()
        {
            List<Customer> customersFirstName = _customerRepo.GetAllCustomersSortedByFirstName();
            List<Customer> customersLastName = _customerRepo.GetAllCustomersSortedByLastName();

            ConsoleKeyInfo userInput = _prompt.PromptUserForSortOption();

            switch (userInput.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    DisplayAllCustomersAlphabeticallyByFirstName();
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    DisplayAllCustomersAlphabeticallyByLastName();
                    break;
                default:
                    break;
            }
            Console.ReadLine();
        }
        private void DisplayAllCustomersAlphabeticallyByFirstName()
        {
            Console.Clear();

            List<Customer> customers = _customerRepo.GetAllCustomersSortedByFirstName();

            foreach(Customer customer in customers)
            {
                Console.WriteLine($"{customer.FullName, -20} {customer.TypeToString(), -20} {customer.GenerateEmailMessage(), -20}\n");
            }
        }
        private void DisplayAllCustomersAlphabeticallyByLastName()
        {
            Console.Clear();

            List<Customer> customers = _customerRepo.GetAllCustomersSortedByLastName();
            foreach (Customer customer in customers)
            {
                Console.WriteLine($"{customer.LastName, -14} {customer.FirstName, -14} {customer.TypeToString(), -18} {customer.GenerateEmailMessage(), -18}\n");
            }
        }
        private void AddACustomer()
        {
            ConsoleKeyInfo userInput = _prompt.PromptUserForCustomerType();

            switch (userInput.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    AddNewPotentialCustomer();
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    AddNewPastCustomer();
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    AddNewCurrentCustomer();
                    break;
                default:
                    break;
            }
        }
        private void DeleteACustomer()
        {
            Console.Clear();
            Console.WriteLine("Delete a customer:");

            string firstName = _prompt.PromptUserForFirstName();
            string lastName = _prompt.PromptUserForLastName();

            Customer customer = _customerRepo.GetCustomerByName(firstName, lastName);

            if(customer != null)
            {
                _customerRepo.RemoveCustomer(customer);
                Console.Clear();
                Console.WriteLine($"Customer {customer.FullName} was successfully removed...");
                Console.WriteLine("Press enter to return to the menu...");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine($"Customer {firstName} {lastName} does not exist...");
                Console.WriteLine("Press enter to return to the menu...");
                Console.ReadLine();
            }
        }
        private void UpdateACustomer()
        {
            Console.Clear();

            Console.WriteLine("Which customer would you like to update?");
            string firstName = _prompt.PromptUserForFirstName();
            string lastName = _prompt.PromptUserForLastName();

            Customer customer = _customerRepo.GetCustomerByName(firstName, lastName);
            
            bool isUserResponseYesToQuestionUpdateName = _prompt.PromptUserYesOrNo("Update a Customer's Name? (Y/N)");
            if (isUserResponseYesToQuestionUpdateName)
            {
                Console.Clear();

                Console.WriteLine("Please Enter New Name:");

                string newFirstName = _prompt.PromptUserForFirstName();
                string newLastName = _prompt.PromptUserForLastName();

                _customerRepo.UpdateCustomerFirstName(customer, newFirstName);
                _customerRepo.UpdateCustomerLastName(customer, newLastName);

                Console.Clear();
                Console.WriteLine($"Customer {firstName} {lastName} was successfully updated to {customer.FullName}.");

                bool isUserResponseYesToQuestionUpdateType = _prompt.PromptUserYesOrNo("Update a Customer's Type? Y/N");
                if (isUserResponseYesToQuestionUpdateType)
                {
                    if (customer is PotentialCustomer)
                    {
                        Console.WriteLine($"Customer is a Potential Customer");
                        bool isUserResponseYesToConvertQuestion = _prompt.PromptUserYesOrNo("Convert Potential Customer to Current Customer? Y/N");
                        if (isUserResponseYesToConvertQuestion)
                        {
                            Console.Clear();

                            CurrentCustomer current = (CurrentCustomer)(customer as PotentialCustomer);
                            _customerRepo.RemoveCustomer(customer);
                            _customerRepo.AddCustomer(current);

                            Console.WriteLine("Customer has been successfully updated...");
                            Console.WriteLine("Press enter to return to main menu...");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Press enter to return to main menu...");
                            Console.ReadLine();
                        }
                    }
                    else if (customer is PastCustomer)
                    {
                        Console.WriteLine($"Customer is a Past Customer");
                        bool isUserResponseYesToConvertQuestion = _prompt.PromptUserYesOrNo("Convert Past Customer to Current Customer? Y/N");
                        if (isUserResponseYesToConvertQuestion)
                        {
                            Console.Clear();

                            CurrentCustomer current = (CurrentCustomer)(customer as PastCustomer);
                            _customerRepo.RemoveCustomer(customer);
                            _customerRepo.AddCustomer(current);

                            Console.WriteLine("Customer has been successfully updated...");
                            Console.WriteLine("Press enter to return to main menu...");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Press enter to return to main menu...");
                            Console.ReadLine();
                        }
                    }
                    else if (customer is CurrentCustomer)
                    {
                        Console.WriteLine($"Customer is a Current Customer");
                        bool isUserResponseYesToConvertQuestion = _prompt.PromptUserYesOrNo("Convert Current Customer to Past Customer? Y/N");
                        if (isUserResponseYesToConvertQuestion)
                        {
                            Console.Clear();

                            PastCustomer past = (PastCustomer)(customer as CurrentCustomer);
                            _customerRepo.RemoveCustomer(customer);
                            _customerRepo.AddCustomer(past);

                            Console.WriteLine("Customer has been successfully updated...");
                            Console.WriteLine("Press enter to return to main menu...");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Press enter to return to main menu...");
                            Console.ReadLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Press enter to return to main menu...");
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Press enter to return to main menu...");
                    Console.ReadLine();
                }
            }
            else
            {
                bool isUserResponseYesToQuestionUpdateType = _prompt.PromptUserYesOrNo("Update a Customer's Type? Y/N");
                if (isUserResponseYesToQuestionUpdateType)
                {
                    if (customer is PotentialCustomer)
                    {
                        Console.WriteLine($"Customer is a Potential Customer");
                        bool isUserResponseYesToConvertQuestion = _prompt.PromptUserYesOrNo("Convert Potential Customer to Current Customer? Y/N");
                        if (isUserResponseYesToConvertQuestion)
                        {
                            Console.Clear();

                            CurrentCustomer current = (CurrentCustomer)(customer as PotentialCustomer);
                            _customerRepo.RemoveCustomer(customer);
                            _customerRepo.AddCustomer(current);

                            Console.WriteLine("Customer has been successfully updated...");
                            Console.WriteLine("Press enter to return to main menu...");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Press enter to return to main menu...");
                            Console.ReadLine();
                        }
                    }
                    else if (customer is PastCustomer)
                    {
                        Console.WriteLine($"Customer is a Past Customer");
                        bool isUserResponseYesToConvertQuestion = _prompt.PromptUserYesOrNo("Convert Past Customer to Current Customer? Y/N");
                        if (isUserResponseYesToConvertQuestion)
                        {
                            Console.Clear();

                            CurrentCustomer current = (CurrentCustomer)(customer as PastCustomer);
                            _customerRepo.RemoveCustomer(customer);
                            _customerRepo.AddCustomer(current);

                            Console.WriteLine("Customer has been successfully updated...");
                            Console.WriteLine("Press enter to return to main menu...");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Press enter to return to main menu...");
                            Console.ReadLine();
                        }
                    }
                    else if (customer is CurrentCustomer)
                    {
                        Console.WriteLine($"Customer is a Current Customer");
                        bool isUserResponseYesToConvertQuestion = _prompt.PromptUserYesOrNo("Convert Current Customer to Past Customer? Y/N");
                        if (isUserResponseYesToConvertQuestion)
                        {
                            Console.Clear();

                            PastCustomer past = (PastCustomer)(customer as CurrentCustomer);
                            _customerRepo.RemoveCustomer(customer);
                            _customerRepo.AddCustomer(past);

                            Console.WriteLine("Customer has been successfully updated...");
                            Console.WriteLine("Press enter to return to main menu...");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Press enter to return to main menu...");
                            Console.ReadLine();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Press enter to return to main menu...");
                    Console.ReadLine();
                }
            }
        }
        private void AddNewPotentialCustomer()
        {
            Console.Clear();
            string firstName = _prompt.PromptUserForFirstName();
            string lastName = _prompt.PromptUserForLastName();
            PotentialCustomer customer = new PotentialCustomer(firstName, lastName);
            _customerRepo.AddCustomer(customer);

            Console.Clear();
            Console.WriteLine("Customer was successfully added...");
            Console.ReadLine();
        }
        private void AddNewPastCustomer()
        {
            Console.Clear();

            string firstName = _prompt.PromptUserForFirstName();
            string lastName = _prompt.PromptUserForLastName();
            PastCustomer customer = new PastCustomer(firstName, lastName);
            _customerRepo.AddCustomer(customer);

            Console.Clear();
            Console.WriteLine("Customer was successfully added...");
            Console.ReadLine();
        }
        private void AddNewCurrentCustomer()
        {
            Console.Clear();

            string firstName = _prompt.PromptUserForFirstName();
            string lastName = _prompt.PromptUserForLastName();
            CurrentCustomer customer = new CurrentCustomer(firstName, lastName);
            _customerRepo.AddCustomer(customer);

            Console.Clear();
            Console.WriteLine("Customer was successfully added...");
            Console.ReadLine();
        }
        private void SeedCustomers()
        {
            PotentialCustomer customer1 = new PotentialCustomer("Bob", "Smith");
            _customerRepo.AddCustomer(customer1);
            
            PotentialCustomer customer2 = new PotentialCustomer("Jeremy", "Adams");
            _customerRepo.AddCustomer(customer2);
            
            CurrentCustomer customer3 = new CurrentCustomer("Selina", "McCoy");
            _customerRepo.AddCustomer(customer3);
            
            CurrentCustomer customer4 = new CurrentCustomer("Emily", "Arnold");
            _customerRepo.AddCustomer(customer4);
            
            PastCustomer customer5 = new PastCustomer("Jim", "Williams");
            _customerRepo.AddCustomer(customer5);
            
            PastCustomer customer6 = new PastCustomer("Henry", "Jones");
            _customerRepo.AddCustomer(customer6);
        }
    }
}