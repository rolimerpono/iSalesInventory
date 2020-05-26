using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    [Serializable]
    public class Product
    {

        public Product()
        {

            PRODUCT_CODE = string.Empty;
            BAR_CODE = string.Empty;
            DESCRIPTION = string.Empty;
            _BRAND = new Brand();
            _CATEGORY = new Category();
            PRICE = "0";
            REORDER_LEVEL = "0";
            VATABLE = false;
        }
        
        public string PRODUCT_CODE { get; set; }
        public string BAR_CODE { get; set; }
        public string DESCRIPTION { get; set; }
        public Brand _BRAND { get; set; }
        public Category _CATEGORY { get; set; }
        public string PRICE { get; set; }
        public string REORDER_LEVEL { get; set; }
        public bool VATABLE { get; set; }
    }
}
