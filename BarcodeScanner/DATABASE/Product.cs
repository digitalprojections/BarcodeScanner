using System;
using System.Collections.Generic;
using System.Text;

namespace BarcodeScanner.DATABASE
{
    public class Product
    {
        public int ProductID { get; set; }

        public string Name { get; set; }
        public string BarCode {
            get { return Name; } 
            set { 
                Name = value;                
            } 
        }
        public string Description { get; set; }
        public int? ProductShelfSelectorID { get; set; }
        public int? CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<ProductShelf> ProductShelfs { get; set; }
        public virtual List<ProductShelfSelector> ProductShelfSelectors { get; set; }
    }

    
    /// <summary>
    /// 50 shelves
    /// </summary>
    public class ProductShelf
    {
        public int ProductShelfID { get; set; }
        public string Name { get; set; }
            
        public virtual List<ProductShelfSelector> ProductShelfSelectors { get; set; }
    }

    public class ProductShelfSelector
    {
        public int ProductShelfSelectorID { get;set; }

        public int On { get; set; }

        public int? ProductID { get; set; }
        public int? ProductShelfID { get; set; }
        public virtual Product Product { get; set; }
        public virtual ProductShelf ProductShelf { get; set; }

    }
}
