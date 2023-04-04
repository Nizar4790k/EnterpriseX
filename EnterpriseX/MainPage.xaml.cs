using EnterpriseX.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EnterpriseX
{
    public partial class MainPage : ContentPage
    {

        List<Customer> myCustomers = new List<Customer>();


        public MainPage()
        {
            InitializeComponent();


        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            myCustomers.Add(new Customer("Juan", "123"));
            myCustomers.Add(new Customer("Pedro", "456"));

            MyListView.ItemsSource = myCustomers;
            MyListView.ItemSelected += MyListView_ItemSelected;

        }


        private async void MyListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            if(e.SelectedItem != null)
            {

                var customer = (Customer)e.SelectedItem;

                await this.Navigation.PushModalAsync(new CustomerDetails(customer));
            }


        }
    }
}
