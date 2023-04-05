using EnterpriseX.Controllers;
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

        List<Customer> myCustomers;
        private bool _isItemTappedHandled = false;


        public  MainPage()
        {
            InitializeComponent();
            Title = "EntrepriseX";
            
            


        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            myCustomers = await new FireBaseHelper().GetAllCustomers();
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
