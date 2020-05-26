using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Vat
    {
        public Vat()
        {
            VAT = 0;
            TRANSACTION_DATE = DateTime.Now.ToString("yyyy-MM-dd");
            TRANSACT_BY = string.Empty;
        
        }

        public double VAT { get; set; }
        public string TRANSACTION_DATE { get; set; }
        public string TRANSACT_BY { get; set; }
    }
}
