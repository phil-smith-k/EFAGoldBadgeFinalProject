using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailClasses
{
    public class PotentialCustomer : Customer
    {
        public string Type { get; } = "Potential Customer";
        public PotentialCustomer() { }
        public PotentialCustomer(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
        public static explicit operator PotentialCustomer(PastCustomer cust) => new PotentialCustomer(cust.FirstName, cust.LastName);
        public static explicit operator PotentialCustomer(CurrentCustomer cust) => new PotentialCustomer(cust.FirstName, cust.LastName);
        public override string GenerateEmailMessage()
        {
            return $"We currently have the lowest rates on Helicopter Insurance!";
        }
        public override string TypeToString()
        {
            return "Potential Customer";
        }
    }
    public class PastCustomer : Customer
    {
        public string Type { get; } = "Past Customer";
        public PastCustomer(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
        public static explicit operator PastCustomer(PotentialCustomer cust) => new PastCustomer(cust.FirstName, cust.LastName);
        public static explicit operator PastCustomer(CurrentCustomer cust) => new PastCustomer(cust.FirstName, cust.LastName);
        public override string GenerateEmailMessage()
        {
            return $"It's been a long time since we've heard from you, we want you back.";
        }
        public override string TypeToString()
        {
            return "Past Customer";
        }
    }
    public class CurrentCustomer : Customer
    {
        public string Type { get; } = "Current Customer";
        public CurrentCustomer(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
        public static explicit operator CurrentCustomer(PotentialCustomer cust) => new CurrentCustomer(cust.FirstName, cust.LastName);
        public static explicit operator CurrentCustomer(PastCustomer cust) => new CurrentCustomer(cust.FirstName, cust.LastName);
        public override string GenerateEmailMessage()
        {
            return $"Thank you for your work with us. We appreciate your loyalty. Here's a coupon.";
        }
        public override string TypeToString()
        {
            return "Current Customer";
        }
    }
}
