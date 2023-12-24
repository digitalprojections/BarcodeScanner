using BarcodeScanner.Commands;
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
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        private ICommand loadedCommand;
        
        public ObservableCollection<Category> Cats { get; set; }
        public ObservableCollection<Product> Prods { get; set; }
        public ObservableCollection<ProductShelf> ProdShelfs { get; set; }
        public ObservableCollection<ProductShelfSelector> ProdShellSels { get; set; }

        public ICommand SelectionChange
        {
            get => selectionChange;
            set
            {
                selectionChange = value;
                OnPropertyChanged(nameof(SelectionChange));
            }
        }

        public CollectionView CategoryView { get; set; }
        public DBContext context = new();
        public ICommand LoadedCommand { get => loadedCommand; set => loadedCommand = value; }
        public IAsyncCommand AddCommand { get; }

        public string Ipaddress
        {
            get => ipaddress; set
            {
                ipaddress = value;
                OnPropertyChanged(nameof(Ipaddress));
            }
        }

        private string ipaddress;
        private ICommand selectionChange;

        public MainViewModel(IShell shell)
        {
            AddCommand = new OpenMenuCommand(shell);
            Load();
        }

        private void Load()
        {
            Ipaddress = "";
            context.Categories.Load();
            context.Products.Load();
            context.ProductShelves.Load();
            context.ProductShelvesSelectors.Load();

            Cats = context.Categories.Local.ToObservableCollection();
            Prods = context.Products.Local.ToObservableCollection();
            ProdShelfs = context.ProductShelves.Local.ToObservableCollection();
            ProdShellSels = context.ProductShelvesSelectors.Local.ToObservableCollection();



            if (LoadedCommand == null)
            {
                LoadedCommand = new Loader(this);
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
            mainViewModel.context.SaveChanges();

        }
    }
}
