using Navigation.ViewModels;
using System;
using System.Diagnostics;
using System.Windows.Input;

namespace Navigation.Commands
{
    public abstract class CommandBase : ICommand
    {        

        public event EventHandler? CanExecuteChanged;

        public CommandBase()
        {     
     
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public abstract void Execute(object? parameter);
    }
}