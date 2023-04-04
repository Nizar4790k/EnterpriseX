using EnterpriseX.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EnterpriseX
{
    public partial class MainPage : ContentPage
    {

        List<Customer> myCustomers = new List<Customer>();
        private bool _isItemTappedHandled = false;


        public MainPage()
        {
            InitializeComponent();


        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            List<string> addresss1 = new List<string>();
            addresss1.Add("En la casa que dice se alquila");
            addresss1.Add("En la casa que dice se alquila1");
            addresss1.Add("En la casa que dice se alquila3");
            List<string> addresss2 = new List<string>();
            addresss2.Add("En la casa que dice se vende");
            addresss2.Add("En la casa que dice se vende1");


            myCustomers.Add(new Customer("Juan", "809111111", DateTime.Parse("1993-02-04 00:00"), "juan@gmail.com", addresss1));
            myCustomers.Add(new Customer("Pedro", "8092222222",DateTime.Parse("1996-06-04 00:00"),"pedro@gmail.com",addresss2));

            MyListView.ItemsSource = myCustomers;
            MyListView.ItemTapped += MyListView_ItemTapped;
        }


        

        private async void MyListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {


            if (!_isItemTappedHandled)
            {
                _isItemTappedHandled = true;
                /* 
                 * Do your item tapped logic here
                 * 
                 * 
                 * 
                 * 
                 * */
                if (e.Item != null)
                {

                    var customer = (Customer)e.Item;
                    Debug.WriteLine(customer.Name);

                    await Navigation.PushModalAsync(new NavigationPage(new CustomerDetails(customer)));

                }


                await Task.Delay(500); // Wait for a short time to ensure the UI thread is not busy
                _isItemTappedHandled = false;
            }



            
           


        }


        
        private async void OnAddClicked(object sender, EventArgs e)
        {

            await Navigation.PushModalAsync(new NavigationPage(new AddCustomer()));


 

        }
        

        
    }
}
