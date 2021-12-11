using System.Collections.Generic;

namespace BarcodeScanner.DATABASE
{
    public class Categories
    {
        public int CategoriesID { get; set; }

        public string Name { get; set; }

        public int ProductsID { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}