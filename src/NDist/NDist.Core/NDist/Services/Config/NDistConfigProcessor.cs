using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Hik.NDist.Services.Config
{
    public class NDistServiceConfigReader
    {
        private readonly string _filePath;

        private static readonly XmlSerializer Serializer;

        static NDistServiceConfigReader()
        {
            Serializer = new XmlSerializer(typeof(NDistServiceConfig));
        }

        public NDistServiceConfigReader(string filePath)
        {
            _filePath = filePath;
        }

        public NDistServiceConfig Read()
        {
            using (var reader = new StreamReader(_filePath, Encoding.UTF8))
            {
                return (NDistServiceConfig)Serializer.Deserialize(reader);
            }
        }
    }
}