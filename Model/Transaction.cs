using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    [Serializable]
    public class Transaction 
    {

        public Transaction()
        {
            TRANSACTION_NO = string.Empty;
            _Product = new Product();
            _Vendor = new Vendor();
            QTY = 0;
            DISCOUNT_PERCENTAGE = 0;
            DISCOUNT = 0;
            VAT_PERCENTAGE = 0;
            VAT = 0;
            TOTAL = 0;
            TRANSACTION_DATE = DateTime.Now.ToString("yyyy-MM-dd");
            TRANSACT_BY = string.Empty;
            MODIFIED_DATE = DateTime.Now.ToString("yyyy-MM-dd");
            MODIFIED_BY = string.Empty;
            VOID_BY = string.Empty;
            REASON = string.Empty;
            STATUS = "";
        }



        public string TRANSACTION_NO { get; set; }
        public Product _Product { get; set; }
        public Vendor _Vendor { get; set; }
        public int QTY { get; set; }
        public double DISCOUNT_PERCENTAGE { get; set; }
        public double DISCOUNT { get; set; }
        public double VAT_PERCENTAGE { get; set; }
        public double VAT { get; set; }
        public double TOTAL { get; set; }
        public string TRANSACTION_DATE { get; set; }
        public string TRANSACT_BY { get; set; }
        public string VOID_BY { get; set; }
        public string MODIFIED_DATE { get; set; }
        public string MODIFIED_BY { get; set; }
        public string REASON { get; set; }
        public string STATUS { get; set; }
    }
}
