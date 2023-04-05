using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace EnterpriseX.Models
{
    public class Customer
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public List<String> AddressList { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public Guid Id { get; set; }
       

        
       public Customer()
        {

        }


        public Customer (string name, string phone, DateTime dateOfBirth, string email,List<String> addressList)
        {
            Name = name;
            Phone = phone;
            DateOfBirth = dateOfBirth;
            Email = email;
            Id = Guid.NewGuid();
            AddressList = addressList;
        }


        public Customer(Guid id,string name, string phone, DateTime dateOfBirth, string email,List<String> addressList)
        {
            Id = id;
            Name = name;
            Phone = phone;
            DateOfBirth = dateOfBirth;
            Email = email;
            AddressList = addressList;
        }
    }
}
