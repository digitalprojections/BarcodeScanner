using System;
using System.Windows.Input;

namespace DCOMProduction.MVVMDemo.byAhmad.ViewModels
{
    internal class CustomerUpdateCommand:ICommand
    {
        private CustomerViewModel _ViewModel;

        public CustomerUpdateCommand(CustomerViewModel viewModel)
        {
            _ViewModel = viewModel;
        }

        #region ICommand Members
        public event EventHandler? CanExecuteChanged{
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value;}
        }

        public bool CanExecute(object? parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object? parameter)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}