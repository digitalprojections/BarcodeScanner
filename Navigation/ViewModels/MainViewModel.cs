using Navigation.Commands;
using Navigation.Models;
using Navigation.Stores;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Navigation.ViewModels
{
    public class MainViewModel : ViewModelBase
    {        
        public CreateProductCommand commandBase { get; set; }

        internal void Prepare()
        {
            title="Salom";
            OnPropertyChanged();
        }

        public ICollection<Item> items = new ObservableCollection<Item>();
        public string? title { get; set; }
        private int i = 0;
        private ProductStore productStore;

        public ObservableCollection<Item> GetItems { get { 
            return (ObservableCollection<Item>)items; 
            } set {
                items = value;
                OnPropertyChanged();
            } }

        public MainViewModel()
        {
            productStore = new ProductStore();
            commandBase = new CreateProductCommand(this, productStore);
            
            items.Add(new Item { Id = 1, Name = "car" });
            items.Add(new Item { Id = 2, Name = "pen" });
            items.Add(new Item { Id = 3, Name = "book" });
            items.Add(new Item { Id = 4, Name = "notepad" });
            items.Add(new Item { Id = 5, Name = "brush" });
            OnPropertyChanged();
        }

        internal void OnExecute()
        {
            //MessageBox.Show("Salom");
            title = $"Salom {i++}";
            
            OnPropertyChanged();
        }
    }
}
