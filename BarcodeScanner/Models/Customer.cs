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
            get;
            private set;
        }
       
        public string this[string columnName]
        {
            get
            {
                if(columnName == "Name")
                {
                    if (string.IsNullOrEmpty(Name))
                    {
                        Error = "Name can`t be null or empty";
                    }else
                    {
                        Error = null;
                    }
                }
                return Error;
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
