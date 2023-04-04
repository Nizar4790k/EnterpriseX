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
    public partial class AddCustomer : ContentPage
    {

    
    
        private Customer mCustomer;
        private StackLayout mAdressLayout;
        private DateTime mDateOfBirth;

        public AddCustomer()
        {
            InitializeComponent();

         
            BindingContext = mCustomer;
            mAdressLayout = AddressLayout;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            DatePicker.Date = DateTime.Now;

          


        }

        private  void OnCreateCustomer(object sender, EventArgs e)
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
                DisplayAlert("Direccion", "Favor asociar una direccion", "Ok");
            }
            else
            {
                DisplayAlert("Insertado", "nombre:" + mCustomer.Name + ",telefono" + mCustomer.Phone + ",fecha " + mCustomer.DateOfBirth.ToString("D"), "Ok");

            }






        }

        private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            mDateOfBirth = e.NewDate;
            
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
                DisplayAlert("Direccion", "Favor asociar una direccion", "Ok");
            }

            





        }


        private void OnRemoveClicked(object sender, EventArgs e)
        {
            // Handle the "Remove" toolbar item click here
        }






    }


}