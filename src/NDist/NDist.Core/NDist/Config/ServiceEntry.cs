using System;
using System.Xml.Serialization;

namespace Hik.NDist.Config
{
    [Serializable]
    public class ServiceEntry
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        //[XmlAttribute("version")]
        //public string Version { get; set; }

        //[XmlAttribute("assemblyName")]
        //public string AssemblyName { get; set; }

        //[XmlAttribute("typeName")]
        //public string TypeName { get; set; }
    }
}