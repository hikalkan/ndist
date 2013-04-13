using System;
using System.Xml.Serialization;

namespace Hik.NDist.Config
{
    [Serializable]
    public class ServiceEntry
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
    }
}