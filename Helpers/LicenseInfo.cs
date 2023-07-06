using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SozaiForms.Helpers
{
    public class LicenseInfo
    {
        [XmlAttribute] public string Dir { get; set; }
        [XmlAttribute] public string License { get; set; }
    }
}
