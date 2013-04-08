using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Hik.NDist.Config
{
    public class NDistConfigProcessor : INDistConfigProcessor
    {
        private static readonly XmlSerializer Serializer;

        static NDistConfigProcessor()
        {
            Serializer = new XmlSerializer(typeof(NDistConfig));
        }

        public NDistConfig Load()
        {
            using (var reader = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "NDistConfig.xml"), Encoding.UTF8))
            {
                return (NDistConfig) Serializer.Deserialize(reader);
            }
        }

        public void Save(NDistConfig config)
        {
            using (var reader = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), "NDistConfig.xml"), false, Encoding.UTF8))
            {
                Serializer.Serialize(reader, config);
            }
        }
    }
}