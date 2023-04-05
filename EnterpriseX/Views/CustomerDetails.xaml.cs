using EnterpriseX.Controllers;
using EnterpriseX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EnterpriseX
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomerDetails : ContentPage
    {

    
    
        private Customer mCustomer;
        private StackLayout mAdressLayout;

        public CustomerDetails(Customer customer)
        {
            InitializeComponent();

            Title = "Customer Details";
            mCustomer = customer;
            BindingContext = mCustomer;
            
            

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            DatePicker.Date = mCustomer.DateOfBirth;

            

            if (mCustomer.AddressList.Count > 0)
            {
                mCustomer.AddressList.ForEach(address =>
                {
                    AddressLayout.Children.Add(new Entry {Text = address });
                });
            }

            mAdressLayout = AddressLayout;




        }

        private async void OnGetBack(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private void OnUpdateCustomer(object sender, EventArgs e)
        {
           mCustomer.Name = BoxName.Text;
           mCustomer.Phone= BoxPhone.Text;
           mCustomer.Email = BoxEmail.Text;




            mCustomer.AddressList.Clear();
            mCustomer.AddressList.TrimExcess();

            for (int i= 3; i < mAdressLayout.Children.Count; i++)
            {


                Entry textBox = (Entry)mAdressLayout.Children[i];

               


                if (!string.IsNullOrEmpty(textBox.Text))
                {
                    mCustomer.AddressList.Add(textBox.Text);
                }
            }

            if (mCustomer.AddressList.Count == 0)
            {
                DisplayAlert("Address", "Please add an address", "Ok");
            }
            else
            {
                 new FireBaseHelper().UpdateCustomer(mCustomer);
                 Navigation.PopModalAsync();

            }






        }

        private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            mCustomer.DateOfBirth = e.NewDate;
            
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
                Entry curentTextBoxDate = (Entry)addressLayout.Children[addressLayout.Children.Count - 1];

                if ((addressLayout.Children.Count == mCustomer.AddressList.Count) && !string.IsNullOrEmpty(curentTextBoxDate.Text))
                {
                    addressLayout.Children.RemoveAt(addressLayout.Children.Count - 1);
                    mCustomer.AddressList.RemoveAt(mCustomer.AddressList.Count - 1);
                }
                else
                {
                    addressLayout.Children.RemoveAt(addressLayout.Children.Count - 1);
                }


            }
            else
            {
                DisplayAlert("Address", "Please type an address", "Ok");
            }

            





        }


        private async void OnRemoveClicked(object sender, EventArgs e)
        {
            new FireBaseHelper().DeleteCustomer(mCustomer.Id);

            await Navigation.PopModalAsync();



            // Handle the "Remove" toolbar item click here
        }






    }


}