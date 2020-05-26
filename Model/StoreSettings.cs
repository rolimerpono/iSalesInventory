using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class StoreSettings
    {

        public StoreSettings()
        {
            STORE_NAME = "ROLLY SARI-SARI STORE";
            ADDRESS = "ANTIPOLO CITY";
            CONTACT_PERSON = "ROLIMER PONO";
            CONTACT_NO = "09773317615";        
        }
        public string STORE_NAME { get; set; }
        public string ADDRESS { get; set; }
        public string CONTACT_PERSON { get; set; }
        public string CONTACT_NO { get; set; }
    }
}
