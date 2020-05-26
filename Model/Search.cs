using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    [Serializable]
    public class Search
    {
        public Search()
        {
            RECORD_TYPE = "";
            RECORD_SEARCH = "";
            DATE_FROM = DateTime.Now.ToString("yyyy-MM-d");
            DATE_TO = DateTime.Now.ToString("yyyy-MM-dd");
            STATUS = "";
        }
      
        public string RECORD_TYPE { get; set; }
        public string RECORD_SEARCH { get; set; }
        public string DATE_FROM { get; set; }
        public string DATE_TO { get; set; }
        public string STATUS { get; set; }
    }
}
