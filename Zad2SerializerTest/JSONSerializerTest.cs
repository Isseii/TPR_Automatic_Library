using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zad2Serializer.ObjectModel;
using Zad2Serializer.Serialization;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Zad2SerializerTest
{
    [TestClass]
    public class JSONSerializerTest
    {
        private A a;
        private B b;
        private C c;

        [TestInitialize()]
        public void SetUp()
        {
             a = new A("Dominik", "Karski", 4124, new DateTime(2019, 12, 1), null);
             b = new B("Sebastian", "Kujawski", 9669, new DateTime(2019, 10, 1), null);
             c = new C("Michał", "Kowalski", 5321, new DateTime(2020, 1, 2), null);

            a.ObjB = b;
            b.ObjC = c;
            c.ObjA = a;
        }

        [TestMethod]
        public void AObjJSONSerializationTest()
        {
            string fileName = "ASerializationTest.json";
            JSONSerialization<A> serializer = new JSONSerialization<A>(fileName, a);
            serializer.Serialize();

            string serializedContent = File.ReadAllText(fileName);
            JObject targetJObject = JsonConvert.DeserializeObject<JObject>(@"{
                                                      ""$id"": ""1"",
                                                      ""$type"": ""Zad2Serializer.ObjectModel.A, Zad2Serializer"",
                                                      ""Name"": ""Dominik"",
                                                      ""LastName"": ""Karski"",
                                                      ""Number"": 4124,
                                                      ""Date"": ""2019-12-01T00:00:00"",
                                                      ""ObjB"": {
                                                                ""$id"": ""2"",
                                                                ""$type"": ""Zad2Serializer.ObjectModel.B, Zad2Serializer"",
                                                                ""Name"": ""Sebastian"",
                                                                ""LastName"": ""Kujawski"",
                                                                ""Number"": 9669,
                                                                ""Date"": ""2019-10-01T00:00:00"",
                                                                ""ObjC"": {
                                                                          ""$id"": ""3"",
                                                                          ""$type"": ""Zad2Serializer.ObjectModel.C, Zad2Serializer"",
                                                                          ""Name"": ""Michał"",
                                                                          ""LastName"": ""Kowalski"",
                                                                          ""Number"": 5321,
                                                                          ""Date"": ""2020-01-02T00:00:00"",
                                                                          ""ObjA"": {
                                                                                    ""$ref"": ""1""
                                                                                    }
                                                                          }
                                                                }
                                                  }");
            JObject resultObject = JsonConvert.DeserializeObject<JObject>(serializedContent);
            Assert.IsTrue(JToken.DeepEquals(resultObject, targetJObject));
        }


        [TestMethod]
        public void BObjJSONSerializationTest()
        {
            string fileName = "BSerializationTest.json";
            JSONSerialization<B> serializer = new JSONSerialization<B>(fileName, b);
            serializer.Serialize();

            string serializedContent = File.ReadAllText(fileName);
            JObject targetJObject = JsonConvert.DeserializeObject<JObject>(@"{
                                                      ""$id"": ""1"",
                                                      ""$type"": ""Zad2Serializer.ObjectModel.B, Zad2Serializer"",
                                                      ""Name"": ""Sebastian"",
                                                      ""LastName"": ""Kujawski"",
                                                      ""Number"": 9669,
                                                      ""Date"": ""2019-10-01T00:00:00"",
                                                      ""ObjC"": {
                                                                    ""$id"": ""2"",
                                                                    ""$type"": ""Zad2Serializer.ObjectModel.C, Zad2Serializer"",
                                                                    ""Name"": ""Michał"",
                                                                    ""LastName"": ""Kowalski"",
                                                                    ""Number"": 5321,
                                                                    ""Date"": ""2020-01-02T00:00:00"",
                                                                    ""ObjA"": {
                                                                          ""$id"": ""3"",
                                                                          ""$type"": ""Zad2Serializer.ObjectModel.A, Zad2Serializer"",
                                                                          ""Name"": ""Dominik"",
                                                                          ""LastName"": ""Karski"",
                                                                          ""Number"": 4124,
                                                                          ""Date"": ""2019-12-01T00:00:00"",
                                                                          ""ObjB"": {
                                                                                    ""$ref"": ""1""
                                                                                    }
                                                                               }
                                                                }
                                                 }");
            JObject resultObject = JsonConvert.DeserializeObject<JObject>(serializedContent);
            Assert.IsTrue(JToken.DeepEquals(resultObject, targetJObject));
        }

        [TestMethod]
        public void CObjJSONSerializationTest()
        {
            string fileName = "CSerializationTest.json";
            JSONSerialization<C> serializer = new JSONSerialization<C>(fileName, c);
            serializer.Serialize();

            string serializedContent = File.ReadAllText(fileName);
            JObject targetJObject = JsonConvert.DeserializeObject<JObject>(@"{   
                                                      ""$id"": ""1"",
                                                      ""$type"": ""Zad2Serializer.ObjectModel.C, Zad2Serializer"",
                                                      ""Name"": ""Michał"",
                                                      ""LastName"": ""Kowalski"",
                                                      ""Number"": 5321,
                                                      ""Date"": ""2020-01-02T00:00:00"",
                                                      ""ObjA"": {
                                                                    ""$id"": ""2"",
                                                                    ""$type"": ""Zad2Serializer.ObjectModel.A, Zad2Serializer"",
                                                                    ""Name"": ""Dominik"",
                                                                    ""LastName"": ""Karski"",
                                                                    ""Number"": 4124,
                                                                    ""Date"": ""2019-12-01T00:00:00"",
                                                                    ""ObjB"": {
                                                                          ""$id"": ""3"",
                                                                          ""$type"": ""Zad2Serializer.ObjectModel.B, Zad2Serializer"",
                                                                          ""Name"": ""Sebastian"",
                                                                          ""LastName"": ""Kujawski"",
                                                                          ""Number"": 9669,
                                                                          ""Date"": ""2019-10-01T00:00:00"",
                                                                          ""ObjC"": {
                                                                                ""$ref"": ""1""
                                                                                    }
                                                                              }
                                                                }
                                                       }");
            JObject resultObject = JsonConvert.DeserializeObject<JObject>(serializedContent);
            Assert.IsTrue(JToken.DeepEquals(resultObject, targetJObject));
        }


        [TestMethod]
        public void AObjJSONDeserializationTest()
        {
            string fileName = "ADeserializationTest.json";
            JSONSerialization<A> serializer = new JSONSerialization<A>(fileName, a);
            serializer.Serialize();

            JSONSerialization<A> tmp = new JSONSerialization<A>("ADeserializationTest.json", a);
            A desResult = tmp.Deserialize();

            Assert.AreEqual(desResult.Name, a.Name);
            Assert.AreEqual(desResult.LastName, a.LastName);
            Assert.AreEqual(desResult.Number, a.Number);
            Assert.AreEqual(desResult.Date, a.Date);
        }

        [TestMethod]
        public void BObjJSONDeserializationTest()
        {
            string fileName = "BDeserializationTest.json";
            JSONSerialization<B> serializer = new JSONSerialization<B>(fileName, b);
            serializer.Serialize();

            JSONSerialization<B> tmp = new JSONSerialization<B>("BDeserializationTest.json", b);
            B desResult = tmp.Deserialize();

            Assert.AreEqual(desResult.Name, b.Name);
            Assert.AreEqual(desResult.LastName, b.LastName);
            Assert.AreEqual(desResult.Number, b.Number);
            Assert.AreEqual(desResult.Date, b.Date);
        }

        [TestMethod]
        public void CObjJSONDeserializationTest()
        {
            string fileName = "CDeserializationTest.json";
            JSONSerialization<C> serializer = new JSONSerialization<C>(fileName, c);
            serializer.Serialize();

            JSONSerialization<C> tmp = new JSONSerialization<C>("CDeserializationTest.json", c);
            C desResult = tmp.Deserialize();

            Assert.AreEqual(desResult.Name, c.Name);
            Assert.AreEqual(desResult.LastName, c.LastName);
            Assert.AreEqual(desResult.Number, c.Number);
            Assert.AreEqual(desResult.Date, c.Date);
        }

    }
}
