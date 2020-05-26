using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    [Serializable]
    public class Stocks
    {

        public Stocks()
        {
            REFERENCE_NO = string.Empty;
            _PRODUCT = new Product();
            QTY = 0;
            STOCK_ON_HAND = 0;
            DISCOUNT_PERCENTAGE = 0;
            DISCOUNT = 0;
            VAT_PERCENTAGE = 0;
            VAT_AMOUNT = 0;
            TOTAL = 0;
            STOCK_DATE = string.Empty;
            _VENDOR = new Vendor();
            REMARKS = string.Empty;
            STATUS = "IN";
        }

        public Product _PRODUCT { get; set; }
        public string REFERENCE_NO { get; set; }
        public int QTY { get; set; }
        public int STOCK_ON_HAND { get; set; }
        public double DISCOUNT_PERCENTAGE { get; set; }
        public double DISCOUNT { get; set; }
        public double VAT_PERCENTAGE { get; set; }
        public double VAT_AMOUNT { get; set; }
        public double TOTAL { get; set; }
        public string STOCK_DATE { get; set; }
        public string STOCK_BY { get; set; }
        public Vendor _VENDOR { get; set; }
        public string REMARKS { get; set; }
        public string STATUS { get; set; }

    }
}
