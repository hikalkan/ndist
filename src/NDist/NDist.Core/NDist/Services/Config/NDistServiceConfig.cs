using System;
using System.Xml.Serialization;

namespace Hik.NDist.Services.Config
{
    [XmlRoot("NDistServiceConfig")]
    [Serializable]
    public class NDistServiceConfig
    {
        [XmlElement("service")]
        public NDistServiceEntry Service { get; set; }
    }
}