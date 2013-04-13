using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Hik.NDist.Config
{
    [XmlRoot("NDistConfig")]
    [Serializable]
    public class NDistConfig
    {
        [XmlArray("settings")]
        [XmlArrayItem("setting", typeof(SettingEntry))]
        public List<SettingEntry> Settings { get; set; }

        [XmlArray("services")]
        [XmlArrayItem("service", typeof(ServiceEntry))]
        public List<ServiceEntry> Services { get; set; }

        [XmlArray("serviceSources")]
        [XmlArrayItem("serviceSource", typeof(ServiceSource))]
        public List<ServiceSource> ServiceSources { get; set; }

        public SettingEntry GetSetting(string name)
        {
            return Settings.Single(setting => setting.Name == name);
        }

        public SettingEntry GetSettingOrNull(string name)
        {
            return Settings.FirstOrDefault(setting => setting.Name == name);
        }
    }
}
