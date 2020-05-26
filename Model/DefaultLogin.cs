using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class DefaultLogin
    {
        private CommonFunction.CommonFunction oFunction = new CommonFunction.CommonFunction();

        public DefaultLogin()
        {
            USERNAME = oFunction.Encrypt("admin");
            PASSWORD = oFunction.Encrypt("rolly");
            NAME = oFunction.Encrypt( "ROLIMER PONO");
            ROLE = oFunction.Encrypt( "SYSTEM ADMINISTRATOR");
            ALLOW_VOID =  true;
        }

        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public string NAME { get; set; }
        public string ROLE { get; set; }
        public bool ALLOW_VOID { get; set; }
    }
}
