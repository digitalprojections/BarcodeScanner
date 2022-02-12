namespace DCOMProduction.MVVMDemo.byAhmad.Models
{
    using System;
    using System.ComponentModel;
 
    public class Customer : INotifyPropertyChanged
    {
        private string _Name;

        /// <summary>
        /// New Customer
        /// </summary>
        public Customer(string customerName)
        {
            _Name = customerName;
        }



        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
                OnPropertyChanged("Name");
            }
        }


        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string v)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }
        #endregion
    }
}
