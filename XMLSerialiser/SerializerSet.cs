using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace XMLSerialiser
{   
    public class Serializerset : XMLSet<Model.SystemConfiguration>
    {
        public Serializerset(string P_sPath)
        {
            if ((P_sPath != string.Empty) && !File.Exists(P_sPath))
            {
                Model.SystemConfiguration set = new Model.SystemConfiguration();
                this.UpdateXmlSerialize(set, P_sPath);
            }
        }
    }
    
}
