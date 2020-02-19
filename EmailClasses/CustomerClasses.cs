using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailClasses
{
    public class PotentialCustomer : Customer
    {
        public override string GenerateEmailMessage()
        {
            return $"We currently have the lowest rates on Helicopter Insurance!";
        }
    }
    public class PastCustomer : Customer
    {
        public override string GenerateEmailMessage()
        {
            return $"It's been a long time since we've heard from you, we want you back.";
        }
    }
    public class CurrentCustomer : Customer
    {
        public override string GenerateEmailMessage()
        {
            return $"Thank you for your work with us. We appreciate your loyalty. Here's a coupon.";
        }
    }
}
