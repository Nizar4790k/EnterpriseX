using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseX.Models
{
    public class Customer
    {
        public string Name { get; set; }
        public string Phone { get; set; }


        public Customer (string name, string phone)
        {
            Name = name;
            Phone = phone;
        }
    }
}
