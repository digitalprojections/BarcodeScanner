using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BarcodeScanner.Models
{
    class Customer : INotifyPropertyChanged, IDataErrorInfo
    {
        private string name;
                
        public Customer(String customerName)
        {
            Name =customerName;
        }

        public string this[string columnName] => throw new NotImplementedException();

        public string Name {
            get {
                return name;
            }
            set {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        #region IDataErrorInfo Members
        public string Error
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        
        #endregion

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyname)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyname));
            }
        }
        # endregion
    }
}
