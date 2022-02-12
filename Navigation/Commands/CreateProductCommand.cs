using Navigation.Models;
using Navigation.Stores;
using Navigation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navigation.Commands
{
    public class CreateProductCommand : CommandBase
    {
        private readonly ProductStore productStore;
        private readonly MainViewModel mainViewModel;

        public CreateProductCommand(MainViewModel mainViewModel, ProductStore productStore)
        {
            this.mainViewModel = mainViewModel;
            this.productStore = productStore;
        }

        public override void Execute(object? parameter)
        {
            Item item = new Item()
            {
                Name = mainViewModel
            }
        }
    }
}
