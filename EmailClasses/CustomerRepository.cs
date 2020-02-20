using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailClasses
{
    public class CustomerRepository
    {
        List<Customer> _customerDirectory = new List<Customer>();

        public bool AddCustomer(Customer customer)
        {
            int initialCount = _customerDirectory.Count;
            _customerDirectory.Add(customer);
            return initialCount + 1 == _customerDirectory.Count;
        }
        public Customer GetCustomerByName(string first, string last)
        {
            try
            {
                Customer customer = _customerDirectory.Single(c => c.FirstName == first && c.LastName == last);
                return customer;
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }
        public bool UpdateCustomerFirstName(Customer customer, string newFirstName)
        {
            customer.FirstName = newFirstName;

            if (customer.FirstName == newFirstName)
                return true;
            else
                return false;
        }
        public bool UpdateCustomerLastName(Customer customer, string newLastName)
        {
            customer.LastName = newLastName;

            if (customer.LastName == newLastName)
                return true;
            else
                return false;
        }
        public bool RemoveCustomer(Customer customer)
        {
            if (customer == null)
            {
                return false;
            }
            else
            {
                int initialCount = _customerDirectory.Count;
                _customerDirectory.Remove(customer);
                return initialCount - 1 == _customerDirectory.Count;
            }
        }
        public List<Customer> GetAllCustomersSortedByFirstName()
        {
            return _customerDirectory.OrderBy(c => c.FirstName).ToList();
        }
        public List<Customer> GetAllCustomersSortedByLastName()
        {
            return _customerDirectory.OrderBy(c => c.LastName).ToList();
        }
    }
}
