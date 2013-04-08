using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Hik.NDist.Services.Config
{
    [Serializable]
    public class NDistServiceEntry
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("version")]
        public string Version { get; set; }

        [XmlAttribute("assemblyName")]
        public string AssemblyName { get; set; }

        [XmlAttribute("typeName")]
        public string TypeName { get; set; }

        [XmlArray("dependencies")]
        [XmlArrayItem("dependency", typeof(NDistServiceDependencyEntry))]
        public List<NDistServiceDependencyEntry> Dependencies { get; set; }
    }
}