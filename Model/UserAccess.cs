using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class UserAccess
    {

        public UserAccess()
        {
            SALES = false;
            PRODUCT = false;
            VENDOR = false;
            STOCK = false;
            CATEGORY = false;
            BRAND = false;
            RECORDS = false;
            SYSTEM_SETTINGS = false;
            USER_SETTINGS = false;
            ROLE = string.Empty;
        }

        public bool SALES { get; set; }
        public bool PRODUCT { get; set; }
        public bool VENDOR { get; set; }
        public bool STOCK { get; set; }
        public bool CATEGORY { get; set; }
        public bool BRAND { get; set; }
        public bool RECORDS { get; set; }
        public bool SYSTEM_SETTINGS { get; set; }
        public bool USER_SETTINGS { get; set; }
        public string ROLE { get; set; }
    }
}
