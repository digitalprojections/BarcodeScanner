using BarcodeScanner.Commands;
using BarcodeScanner.DATABASE;
using BarcodeScanner.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;

namespace BarcodeScanner.ViewModels
{
    internal class CustomerViewModel
    {
        DBContext dBContext = new();
        
        public ObservableCollection<Category> Cats { get; set; }
        public ObservableCollection<Product> Prods { get; set; }
        public ObservableCollection<ProductShelf> ProdShelfs { get; set; }
        public ObservableCollection<ProductShelfSelector> ProdShellSels { get; set; }

        public CollectionViewSource cViewSource = new CollectionViewSource();

        private readonly ICollectionView customerView;
        public ICollectionView CustomerView
        {
            get { return customerView; }
        }
        public CustomerViewModel()
        {
            Customer = new Customer();
            dBContext.Customers.Load();
            dBContext.Products.Load();
            dBContext.ProductShelves.Load();
            dBContext.ProductShelvesSelectors.Load();

            Cats = dBContext.Categories.Local.ToObservableCollection();
            Prods = dBContext.Products.Local.ToObservableCollection();
            ProdShelfs = dBContext.ProductShelves.Local.ToObservableCollection();
            ProdShellSels = dBContext.ProductShelvesSelectors.Local.ToObservableCollection();

            UpdateCommand = new CustomerUpdateCommand(this);
            customerView = CollectionViewSource.GetDefaultView(Customers);
            customerView.Filter = delegate (object item) {
                return ((Customer)item).Name == "okkljl";
            };



        }


        public void SaveChanges()
        {
            

            Customers.Add(Customer);
            dBContext.SaveChanges();
            //Debug.Assert(false, $"{name} was updated.");
        }

        public ICommand UpdateCommand
        {
            get;
            private set;
        }
        public ObservableCollection<Customer> Customers { get; set; }
        public Customer Customer { get; private set; }
        public CollectionViewSource CViewSource { get => cViewSource;}
    }
}
