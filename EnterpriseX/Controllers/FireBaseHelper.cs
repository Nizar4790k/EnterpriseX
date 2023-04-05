using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseX.Models;
using Firebase.Database;
using Firebase.Database.Query;
using static Xamarin.Essentials.Permissions;
using Xamarin.Essentials;
using System.Diagnostics;

namespace EnterpriseX.Controllers
{
    internal class FireBaseHelper
    {

        private FirebaseClient firebase;

        public FireBaseHelper()
        {
            this.firebase = new FirebaseClient("https://enterprisex-c5070-default-rtdb.firebaseio.com/");
        }


        public async Task<List<Customer>> GetAllCustomers()
        {
            try
            {
                return (await firebase
           .Child("Customers")
           .OnceAsync<Customer>()).Select(item => new Customer(
            item.Object.Id, item.Object.Name, item.Object.Phone, item.Object.DateOfBirth,
           item.Object.Email, item.Object.AddressList)).ToList();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return null;
        }


        public async Task AddCustomer(Customer customer)
        {

            await firebase
              .Child("Customers")
              .PostAsync(customer);
        }

        public async Task UpdateCustomer(Customer customer)
        {
            var toUpdatePerson = (await firebase
              .Child("Customers")
              .OnceAsync<Customer>()).Where(a => a.Object.Id == customer.Id).FirstOrDefault();

            await firebase
              .Child("Customers")
              .Child(toUpdatePerson.Key)
              .PutAsync(customer);
        }

        public async Task DeleteCustomer(Guid id)
        {
            var toDeletePerson = (await firebase
              .Child("Customers")
              .OnceAsync<Customer>()).Where(a => a.Object.Id == id).FirstOrDefault();
            await firebase.Child("Customers").Child(toDeletePerson.Key).DeleteAsync();

        }






    }
}
