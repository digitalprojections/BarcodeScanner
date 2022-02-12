using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Navigation.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName = null)
        {
            Debug.WriteLine("changed");
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void OnCollectionChanged()
        {

        }

        public virtual void Dispose()
        {            
        }
    }
}
