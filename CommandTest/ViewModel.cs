using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CommandTest
{
    public class ViewModel : ObservableObject
    {
        private ObservableCollection<TodoItem> _todoItems;
        public ObservableCollection<TodoItem> TodoItems
        {
            get { return this._todoItems; }
            set { 
                this._todoItems = value;
                OnPropertyChanged(nameof(TodoItems));
            }
        }

        public ICommand LoadTodoItemsCommand { get; set; }

        public ViewModel()
        {
            this.LoadTodoItemsCommand = new Command(this);
        }
    }
}
