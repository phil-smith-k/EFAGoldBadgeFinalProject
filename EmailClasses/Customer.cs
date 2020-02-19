﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailClasses
{
    public abstract class Customer
    {
        public Customer() { }
        public Customer(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return $"{this.FirstName} {this.LastName}";
            }
        }
        public abstract string GenerateEmailMessage();
    }
}
