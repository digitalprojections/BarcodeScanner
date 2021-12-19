using BarcodeScanner.Commands;
using BarcodeScanner.Models;
using System;
using System.Windows.Input;

namespace BarcodeScanner.ViewModels
{
    internal class CustomerViewModel
    {
        private Customer _Customer;
        public CustomerViewModel()
        {
            _Customer = new Customer("David");
            UpdateCommand = new CustomerUpdateCommand(this);

        }       
        

        public Customer Customer
        {
            get
            {
                return _Customer;
            }
        }

        public void SaveChanges()
        {
            string name = _Customer.Name;
            //Debug.Assert(false, $"{name} was updated.");
        }

        public ICommand UpdateCommand
        {
            get;
            private set;
        }
        
    }
}
