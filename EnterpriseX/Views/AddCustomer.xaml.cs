using EnterpriseX.Controllers;
using EnterpriseX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EnterpriseX
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddCustomer : ContentPage
    {

    
    
        private Customer mCustomer;
        private StackLayout mAdressLayout;
        private DateTime mDateOfBirth;

        public AddCustomer()
        {
            InitializeComponent();

            Title = "Add Customer";
         
            BindingContext = mCustomer;
            mAdressLayout = AddressLayout;
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            DatePicker.Date = DateTime.Now;

          


        }

        private async void OnGetBack(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private async void OnCreateCustomer(object sender, EventArgs e)
        {

            mCustomer = new Customer(BoxName.Text, BoxPhone.Text, mDateOfBirth, BoxEmail.Text, new List<string>());

         



            mCustomer.AddressList.Clear();
            mCustomer.AddressList.TrimExcess();

            if(mAdressLayout.Children.Count > 2)
            {
                for (int i = 3; i < mAdressLayout.Children.Count; i++)
                {


                    Entry textBox = (Entry)mAdressLayout.Children[i];




                    if (!string.IsNullOrEmpty(textBox.Text))
                    {
                        mCustomer.AddressList.Add(textBox.Text);
                    }
                }

                   
            }


           

            if (mCustomer.AddressList.Count == 0)
            {
                await DisplayAlert("Address", "Please add an address", "Ok");
                return;
            }else if (!IsValidEmail(mCustomer.Email))
            {
                await DisplayAlert("Address", "Please add a valid email", "Ok");
                return;
            }
            else
            {
                await new FireBaseHelper().AddCustomer(mCustomer);
                await Navigation.PopModalAsync();

            }










        }

        private bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }


        private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            mDateOfBirth = e.NewDate;
            
        }

        private void OnAddressAdded(object sender, EventArgs e)
        {
            
            var button = (Button) sender;

            StackLayout addressLayout = (StackLayout)button.Parent;
            addressLayout.Children.Add(new Entry{ Placeholder = "Add the new address" });

     


        }


        private void OnAddressRemoved(object sender, EventArgs e)
        {

            var button = (Button)sender;

            StackLayout addressLayout = (StackLayout)button.Parent;
            
            

            

            if (addressLayout.Children.Count != 3)


            {
               
                addressLayout.Children.RemoveAt(addressLayout.Children.Count - 1);


            }
            else
            {
                DisplayAlert("Address", "Please add an address", "Ok");
            }

            





        }


        






    }


}