using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class SystemConfiguration
    {
        CommonFunction.CommonFunction oFunction = new CommonFunction.CommonFunction();
        public SystemConfiguration()
        {
            _DefaultLogin = new DefaultLogin();
            _StoreSettings = new StoreSettings();
            DatabaseConnectionString = oFunction.Encrypt(@"Data Source=.\SQLSERVERR2;Initial Catalog=iSalesInventory;Integrated Security=True");
            MasterDatabaseConnectionString = oFunction.Encrypt(@"Data Source=.\SQLSERVERR2;Initial Catalog=master;Integrated Security=True");
        }        

        public DefaultLogin _DefaultLogin { get; set; }
        public StoreSettings _StoreSettings { get; set; }
        public string DatabaseConnectionString { get; set; }
        public string MasterDatabaseConnectionString { get; set; }

    }
}
