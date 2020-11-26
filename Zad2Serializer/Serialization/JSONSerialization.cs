using System.IO;
using Newtonsoft.Json;

namespace Zad2Serializer.Serialization
{
    public class JSONSerialization<T>
    {
        private string _fileName;
        private T _obj;
        private JsonSerializerSettings _jsonSettings;

        public JSONSerialization(string fileName, T obj)
        {
            _fileName = fileName;
            _obj = obj;
            _jsonSettings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                PreserveReferencesHandling = PreserveReferencesHandling.All
            };
        }

        public void serialize()
        {
            if (File.Exists(_fileName))
            {
                File.Delete(_fileName);
            }

            string json = JsonConvert.SerializeObject(_obj, Formatting.Indented, _jsonSettings);
            File.WriteAllText(_fileName, json);
        }

        public T deserialize()
        {
            if (!File.Exists(_fileName))
            {
                throw new FileNotFoundException();
            }

            string json = File.ReadAllText(_fileName);
            T deserializedObject = JsonConvert.DeserializeObject<T>(json, _jsonSettings);
            return deserializedObject;
        }
    }
}
