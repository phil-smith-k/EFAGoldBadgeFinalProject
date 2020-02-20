using System;
using System.Collections.Generic;
using EmailClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmailTests
{
    [TestClass]
    public class EmailRepositoryTests
    {
        CustomerRepository _repo = new CustomerRepository();

        [TestInitialize]
        public void Arrange()
        {
            PastCustomer customer1 = new PastCustomer("Lina", "Smith");
            _repo.AddCustomer(customer1);

            PotentialCustomer customer2 = new PotentialCustomer("Kel", "Smith");
            _repo.AddCustomer(customer2);

            CurrentCustomer customer3 = new CurrentCustomer("Eric", "Smith");
            _repo.AddCustomer(customer3);

            PastCustomer customer4 = new PastCustomer("Chris", "Forsythe");
            _repo.AddCustomer(customer4);

            CurrentCustomer customer5 = new CurrentCustomer("Jacob", "Bullock");
            _repo.AddCustomer(customer5);

            PotentialCustomer customer6 = new PotentialCustomer("Kate", "Harrison");
            _repo.AddCustomer(customer6);
        }
        [TestMethod]
        public void AddCustomer_ShouldReturnTrue()
        {
            //Arrange
            PastCustomer pastCustomer = new PastCustomer("Bob", "Smith");
            CustomerRepository repo = new CustomerRepository();

            //Act
            bool wasAdded = repo.AddCustomer(pastCustomer);

            //Assert
            Assert.IsTrue(wasAdded);
        }
        [TestMethod]
        public void GetCustomerByName_ShouldReturnCorrectCustomer()
        {
            //Arrange - Test Init
            //Act
            var customer = _repo.GetCustomerByName("Kate", "Harrison");

            //Assert
            Assert.AreEqual("Kate Harrison", customer.FullName);
        }
        [TestMethod]
        public void UpdateCustomerFirstName_ShouldUpdateName()
        {
            //Arrange - Test Init
            string expected = "Christine";
            Customer customer = _repo.GetCustomerByName("Lina", "Smith");

            //Act
            _repo.UpdateCustomerFirstName(customer, "Christine");

            //Assert
            Assert.AreEqual(expected, customer.FirstName);
        }
        [TestMethod]
        public void UpdateCustomerLastName_ShouldUpdateName()
        {
            //Arrange - Test Init
            string expected = "McDaniels";
            Customer customer = _repo.GetCustomerByName("Eric", "Smith");

            //Act 
            _repo.UpdateCustomerLastName(customer, "McDaniels");

            //Assert
            Assert.AreEqual(expected, customer.LastName);
        }
        [TestMethod]
        public void RemoveCustomer_ShouldReturnTrue()
        {
            //Arrange - Test Init
            Customer customerToRemove = _repo.GetCustomerByName("Jacob", "Bullock");

            //Act
            bool wasCustomerRemoved = _repo.RemoveCustomer(customerToRemove);

            //Assert
            Assert.IsTrue(wasCustomerRemoved);
        }
        [TestMethod]
        public void RemoveCustomerNull_ShouldReturnFalse()
        {
            //Arrange - Test Init
            Customer customerToRemove = _repo.GetCustomerByName("Jacob", "Bulloc");

            //Act
            bool wasCustomerRemoved = _repo.RemoveCustomer(customerToRemove);

            //Assert
            Assert.IsFalse(wasCustomerRemoved);
        }
        [TestMethod]
        public void GetAllCustomersSortedByFirstName_ShouldReturnCorrectCustomer()
        {
            //Arrange - Test Init

            //Act
            List<Customer> customers = _repo.GetAllCustomersSortedByFirstName();

            //Assert
            Assert.IsTrue(customers[0].FirstName == "Chris");
            Assert.IsTrue(customers[customers.Count - 1].FirstName == "Lina");
        }
        [TestMethod]
        public void GetAllCustomersSortedByLastName_ShouldReturnCorrectCustomer()
        {
            //Arrange - TestInit

            //Act
            List<Customer> customers = _repo.GetAllCustomersSortedByLastName();

            //Assert
            Assert.IsTrue(customers[0].LastName == "Bullock");
            Assert.IsTrue(customers[customers.Count - 1].LastName == "Smith");
        }
        [TestMethod]
        public void ExplicitOperatorTest_ShouldConvertCustomerType()
        {
            //Works
            PotentialCustomer potential = new PotentialCustomer();
            CurrentCustomer current = (CurrentCustomer)potential;

            //Works
            Customer customer = _repo.GetCustomerByName("Lina", "Smith");
            CurrentCustomer anotherCurrent = (CurrentCustomer)(potential as PotentialCustomer);
        }
    }
}