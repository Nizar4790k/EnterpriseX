using EnterpriseX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EnterpriseX
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomerDetails : ContentPage
    {

        private string selectedDate;
        private int addressCounter = 0;
        private StackLayout addressLayout;

        public CustomerDetails(Customer customer)
        {
            InitializeComponent();
            BindingContext = customer;

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
           
            
            
        }

        private  void OnUpdateCustomer(object sender, EventArgs e)
        {
            string name = BoxName.Text;
            string phone = BoxPhone.Text;
            
           
           
            DisplayAlert("Actualizado", "nombre:" + name + ",telefono" + phone+",fecha "+selectedDate,"Ok");
           
            
            

        }

        private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            selectedDate = e.NewDate.ToString("D");
        }

        private void OnAddressAdded(object sender, EventArgs e)
        {
            
            var button = (Button) sender;

            StackLayout addressLayout = (StackLayout)button.Parent;
            addressLayout.Children.Add(new Entry{ Placeholder = "Inserte la nueva direccion" });

     


        }


        private void OnAddressRemoved(object sender, EventArgs e)
        {

            var button = (Button)sender;

            StackLayout addressLayout = (StackLayout)button.Parent;
            int last_position = addressLayout.Children.Count;
            addressLayout.Children.RemoveAt(last_position - 1);





        }




       
    }


}