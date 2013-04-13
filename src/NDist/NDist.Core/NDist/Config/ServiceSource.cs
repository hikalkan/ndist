using System;
using System.Xml.Serialization;

namespace Hik.NDist.Config
{
    [Serializable]
    public class ServiceSource
    {
        [XmlAttribute("type")]
        public string Type { get; set; }

        [XmlAttribute("address")]
        public string Address { get; set; }
    }
}