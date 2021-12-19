using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using BarcodeScanner.ViewModels;

namespace BarcodeScanner.Commands
{
    internal class CustomerUpdateCommand : ICommand
    {
        private CustomerViewModel _viewModel;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public CustomerUpdateCommand(CustomerViewModel viewModel)
        {
            _viewModel = viewModel;
        }


        public bool CanExecute(object parameter)
        {
            return _viewModel.CanUpdate;
        }

        public void Execute(object parameter)
        {
            _viewModel.SaveChanges();
        }
        
    }
}
