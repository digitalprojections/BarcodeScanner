using System;
using System.Collections.Generic;
using System.Text;

namespace BarcodeScanner.DATABASE
{
    public class Product
    {
        public int ProductID { get; set; }

        public string Name { get; set; }
        public string BarCode { get; set; }
        public string Description { get; set; }
    
        public int CategoriesID { get; set; }
        public virtual Categories Categories { get; set; }
}
}
