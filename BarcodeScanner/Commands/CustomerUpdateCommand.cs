using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using BarcodeScanner.ViewModels;

namespace BarcodeScanner.Commands
{
    internal class CustomerUpdateCommand : ICommand
    {
        private CustomerViewModel viewModel;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public CustomerUpdateCommand(CustomerViewModel viewModel)
        {
            this.viewModel = viewModel;
        }


        public bool CanExecute(object parameter)
        {            
            return !String.IsNullOrWhiteSpace(this.viewModel.Customer.Name);
        }

        public void Execute(object parameter)
        {
            viewModel.SaveChanges();
        }
        
    }
}
