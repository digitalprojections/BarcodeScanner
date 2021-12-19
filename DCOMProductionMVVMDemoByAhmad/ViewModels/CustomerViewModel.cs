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
            UpdateCommand = new CustomerUpdateCommand();
        }


        public ICommand UpdateCommand()
        {
            get;
            private set;
        }
        

        public Customer Customer { get => customer; }
        
        public void SaveChanges()
        {
            Debug.Assert(false, $"My names is {customer.Name}");
        }
    }
}
