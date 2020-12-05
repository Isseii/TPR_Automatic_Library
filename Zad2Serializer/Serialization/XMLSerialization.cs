using System.IO;
using System.Xml;
using Newtonsoft.Json;


namespace Zad2Serializer.Serialization
{
    public class XMLSerialization<T>
    {
        private string _fileName;
        private T _obj;
        private JsonSerializerSettings _jsonSettings;

        public XMLSerialization(string fileName, T obj)
        {
            _fileName = fileName;
            _obj = obj;
            _jsonSettings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                PreserveReferencesHandling = PreserveReferencesHandling.All
            };
        }

        public void Serialize()
        {
            if (File.Exists(_fileName))
            {
                File.Delete(_fileName);
            }

            string json = JsonConvert.SerializeObject(_obj, Newtonsoft.Json.Formatting.Indented, _jsonSettings);
            XmlDocument doc = (XmlDocument)JsonConvert.DeserializeXmlNode(json, "root");

            doc.Save(_fileName);

        }

        public T Deserialize()
        {
            if (!File.Exists(_fileName))
            {
                throw new FileNotFoundException();
            }

            string xml = File.ReadAllText(_fileName);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);

            string jsonText = JsonConvert.SerializeXmlNode(doc, Newtonsoft.Json.Formatting.Indented, true);
            T deserializedObject = JsonConvert.DeserializeObject<T>(jsonText, _jsonSettings);
            return deserializedObject;
        }
    }
}
