namespace BarcodeScanner.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;
    using System.ComponentModel;

    internal class CustomerInfoViewModel : INotifyPropertyChanged
    {
        private string info;

        /// <summary>
        /// Get or set customer info
        /// </summary>
        public string Info { get
            {
                return info;
            } set { 
                info = value;
                OnPropertyChanged("Info");
            } 
        }
        
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
