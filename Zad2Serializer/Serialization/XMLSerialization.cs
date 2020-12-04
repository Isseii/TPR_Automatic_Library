using System;
using System.IO;
using System.Xml;
using System.Runtime.Serialization;

namespace Zad2Serializer.Serialization
{
    class XMLSerialization<T>
    {
        private string _fileName;
        private T _obj;


        public XMLSerialization(string fileName, T obj)
        {
            _fileName = fileName;
            _obj = obj;
        }

        public void Serialize()
        {
            if (File.Exists(_fileName))
            {
                File.Delete(_fileName);
            }

            XmlWriter writer = XmlWriter.Create(_fileName, new XmlWriterSettings() { Indent = true });
            DataContractSerializer ser = new DataContractSerializer(typeof(T));
            ser.WriteObject(writer, _obj);
            writer.Close();
        }

        public T Deserilize()
        {
            FileStream fs = new FileStream(_fileName, FileMode.Open);
            XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
            DataContractSerializer ser = new DataContractSerializer(typeof(T));

            T deserializedObject = (T)ser.ReadObject(reader, true);
            reader.Close();
            fs.Close();
            return deserializedObject;
        }
    }
}
