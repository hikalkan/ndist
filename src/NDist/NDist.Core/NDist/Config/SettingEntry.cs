using System;
using System.Xml.Serialization;

namespace Hik.NDist.Config
{
    [Serializable]
    public class SettingEntry
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("value")]
        public string Value { get; set; }
    }
}