using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    [Serializable]
    public class Brand
    {

        public Brand()
        {
            ID = string.Empty;
            BRAND = string.Empty;
            STATUS = "ACTIVE";
        }
        public string ID { get; set; }
        public string BRAND { get; set; }
        public string STATUS { get; set; }
    }
}
