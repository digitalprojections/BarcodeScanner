using BarcodeScanner.DATABASE;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace BarcodeScanner.ViewModels
{
    public class MainViewModel : INotifyCollectionChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        private ICommand loadedCommand;

        public ObservableCollection<Category> Cats { get; set; }
        public ObservableCollection<Product> Prods { get; set; }
        public ObservableCollection<ProductShelf> ProdShelfs { get; set; }
        public ObservableCollection<ProductShelfSelector> ProdShellSels { get; set; }

        public CollectionView CategoryView { get; set; }
        public DBContext dBContext = new();
        public ICommand LoadedCommand { get => loadedCommand; set => loadedCommand = value; }
        public string Ipaddress { get => ipaddress; set
            {
                ipaddress = value;
                OnPropertyChanged();
            } 
        }

        private string ipaddress;

        public MainViewModel()
        {
            Load();
        }

        private void Load()
        {
            Ipaddress = "";
            dBContext.Categories.Load();
            dBContext.Products.Load();
            dBContext.ProductShelves.Load();
            dBContext.ProductShelvesSelectors.Load();

            Cats = dBContext.Categories.Local.ToObservableCollection();
            Prods = dBContext.Products.Local.ToObservableCollection();
            ProdShelfs = dBContext.ProductShelves.Local.ToObservableCollection();
            ProdShellSels = dBContext.ProductShelvesSelectors.Local.ToObservableCollection();

            

            if (LoadedCommand == null)
            {
                LoadedCommand=new Loader(this);
            }

           
        }

        public bool Contains(object de)
        {
            Category c = de as Category;
            //Return members whose Orders have not been filled
            return (c.CategoryID == 1);
        }

        private ICollection<ProductShelf> GetShelves(int ptracker)
        {
            var list = new List<ProductShelf>();

            list.Add(new ProductShelf { Name = "Shelf", ProductShelfID = ptracker });
            return list;

        }
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
    public class Loader : ICommand
    {
        private MainViewModel mainViewModel;

        public Loader(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            //Your Code
            mainViewModel.dBContext.SaveChanges();

        }
    }
}
