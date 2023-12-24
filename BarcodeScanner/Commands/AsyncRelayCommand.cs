using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BarcodeScanner.Commands
{
    public abstract class AsyncRelayCommand : IAsyncCommand
    {
        private ObservableCollection<Task> runningTasks;

        protected AsyncRelayCommand()
        {
            runningTasks = new ObservableCollection<Task>();
            runningTasks.CollectionChanged += OnRunningTasksChanged;
        }

        private void OnRunningTasksChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            CommandManager.InvalidateRequerySuggested();
        }

        public IEnumerable<Task> RunningTasks {
            get => runningTasks; 
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
        

        bool ICommand.CanExecute(object parameter)
        {
            return CanExecute();
        }

        async void ICommand.Execute(object parameter)
        {
            Task runningTask = ExecuteAsync();
            runningTasks.Add(runningTask);

            try
            {
                await runningTask;
            }
            finally
            {
                runningTasks.Remove(runningTask);
            }
        }



        public abstract Task ExecuteAsync();
        public abstract bool CanExecute();
    }
    public abstract class AsyncRelayCommand<T> : IAsyncCommand<T>
    {
        private ObservableCollection<Task> runningTasks;

        protected AsyncRelayCommand()
        {
            runningTasks = new ObservableCollection<Task>();
            runningTasks.CollectionChanged += OnRunningTasksChanged;
        }

        private void OnRunningTasksChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            CommandManager.InvalidateRequerySuggested();
        }

        public IEnumerable<Task> RunningTasks
        {
            get => runningTasks;
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }


        bool ICommand.CanExecute(object parameter)
        {
            return CanExecute((T)parameter);
        }

        async void ICommand.Execute(object parameter)
        {
            Task runningTask = ExecuteAsync((T)parameter);
            runningTasks.Add(runningTask);

            try
            {
                await runningTask;
            }
            finally
            {
                runningTasks.Remove(runningTask);
            }
        }



        public abstract Task ExecuteAsync(T parameter);
        public abstract bool CanExecute(T parameter);
    }
    public interface IAsyncCommand : ICommand
    {
        IEnumerable<Task> RunningTasks { get; }
        bool CanExecute();
        Task ExecuteAsync();
    }
    public interface IAsyncCommand<in T> : ICommand
    {
        IEnumerable<Task> RunningTasks { get; }
        bool CanExecute(T parameter);
        Task ExecuteAsync(T parameter);
    }
}