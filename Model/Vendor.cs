using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    [Serializable]
    public class Vendor
    {

        public Vendor()
        {
            ID = string.Empty;
            VENDOR = string.Empty;
            ADDRESS = string.Empty;
            CONTACT_PERSON = string.Empty;
            TELEPHONE_NUMBER = string.Empty;
            EMAIL = string.Empty;
            PHONE_NO = string.Empty;
            FAX_NO = string.Empty;
            STATUS = string.Empty;
        }
        public string ID { get; set; }
        public string VENDOR { get; set; }
        public string ADDRESS { get; set; }
        public string CONTACT_PERSON { get; set; }
        public string TELEPHONE_NUMBER { get; set; }
        public string EMAIL { get; set; }
        public string PHONE_NO { get; set; }
        public string FAX_NO { get; set; }
        public string STATUS { get; set; }
    }
}
