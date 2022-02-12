using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BarcodeScanner.DATABASE
{
    public class Category
    {
        public int CategoryID { get; set; }

        public string Name { get; set; }
                
        public virtual List<Product> Products { get; set; }
    }
}