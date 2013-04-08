using System;
using System.Xml.Serialization;

namespace Hik.NDist.Services.Config
{
    [Serializable]
    public class NDistServiceDependencyEntry
    {
        [XmlAttribute("serviceName")]
        public string ServiceName { get; set; }

        [XmlAttribute("minVersion")]
        public string MinVersion { get; set; }
    }
}