using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class User
    {
        public User()
        {
            ID = string.Empty;
            FIRST_NAME = string.Empty;
            MIDDLE_NAME = string.Empty;
            LAST_NAME = string.Empty;
            CONTACT_NO = "00000000000";
            ROLE = string.Empty;
            USERNAME = string.Empty;
            PASSWORD = string.Empty;
            ADDED_DATE = DateTime.Now.ToString("yyyy-MM-dd");
            ADDED_BY = string.Empty;
            MODIFIED_DATE = DateTime.Now.ToString("yyyy-MM-dd");
            STATUS = "ACTIVE";
            ALLOWED_VOID = 0;
        }

        public string ID { get; set; }
        public string FIRST_NAME { get; set; }
        public string MIDDLE_NAME { get; set; }
        public string LAST_NAME { get; set; }
        public string CONTACT_NO { get; set; }
        public string ROLE { get; set; }
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public string ADDED_DATE { get; set; }
        public string ADDED_BY { get; set; }
        public string MODIFIED_DATE { get; set; }
        public string MODIFIED_BY { get; set; }
        public string STATUS { get; set; }
        public int ALLOWED_VOID { get; set; }       
    }
}
