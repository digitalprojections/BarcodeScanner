namespace DCOMProduction.MVVMDemo.byAhmad.ViewModels
{
    using DCOMProduction.MVVMDemo.byAhmad.Models;
    using System.Diagnostics;
    using System.Windows.Input;

    internal class CustomerViewModel
    {
        
        private Customer customer;
        /// <summary>
        /// new customer viewmodel
        /// </summary>
        public CustomerViewModel()
        {
            customer = new Customer("Ahmad");
            UpdateCommand = new CustomerUpdateCommand(this);
        }


        public ICommand UpdateCommand
        {
            get;
            private set;
        }
        

        public Customer Customer { get => customer; }
        public bool CanUpdate { get
            {
                if(customer == null)
                    return false;
                return !string.IsNullOrWhiteSpace(Customer.Name);

            } 
        }

        public void SaveChanges()
        {
            Debug.Assert(false, $"My names is {customer.Name}");
        }
    }
}
