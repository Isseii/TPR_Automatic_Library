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
             a = new A("Dominick", "Carski", 2137, new DateTime(2019, 12, 1), null);
             b = new B("Sebaschan", "Kijawiński", 9669, new DateTime(2019, 10, 1), null);
             c = new C("Michał", "Karbowany", 5321, new DateTime(2020, 1, 2), null);

            a.ObjB = b;
            b.ObjC = c;
            c.ObjA = a;
        }

        [TestMethod]
        public void AObjSerializationTest()
        {
            string fileName = "ASerializationTest.json";
            JSONSerialization<A> serializer = new JSONSerialization<A>(fileName, a);
            serializer.serialize();

            string serializedContent = File.ReadAllText(fileName);
            JObject targetJObject = JsonConvert.DeserializeObject<JObject>(@"{
                                                     ""$id"": ""1"",
                                                     ""$type"": ""Zad2Serializer.ObjectModel.A, Zad2Serializer"",
                                                      ""Name"": ""Dominick"",
                                                      ""LastName"": ""Carski"",
                                                      ""Number"": 2137,
                                                      ""Date"": ""2019-12-01T00:00:00"",
                                                      ""ObjB"": {
                                                                ""$id"": ""2"",
                                                                ""$type"": ""Zad2Serializer.ObjectModel.B, Zad2Serializer"",
                                                                ""Name"": ""Sebaschan"",
                                                                ""LastName"": ""Kijawiński"",
                                                                ""Number"": 9669,
                                                                ""Date"": ""2019-10-01T00:00:00"",
                                                                ""ObjC"": {
                                                                          ""$id"": ""3"",
                                                                          ""$type"": ""Zad2Serializer.ObjectModel.C, Zad2Serializer"",
                                                                          ""Name"": ""Michał"",
                                                                          ""LastName"": ""Karbowany"",
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
        public void BObjSerializationTest()
        {
            string fileName = "BSerializationTest.json";
            JSONSerialization<B> serializer = new JSONSerialization<B>(fileName, b);
            serializer.serialize();

            string serializedContent = File.ReadAllText(fileName);
            JObject targetJObject = JsonConvert.DeserializeObject<JObject>(@"{
                                                      ""$id"": ""1"",
                                                      ""$type"": ""Zad2Serializer.ObjectModel.B, Zad2Serializer"",
                                                      ""Name"": ""Sebaschan"",
                                                      ""LastName"": ""Kijawiński"",
                                                      ""Number"": 9669,
                                                      ""Date"": ""2019-10-01T00:00:00"",
                                                      ""ObjC"": {
                                                                    ""$id"": ""2"",
                                                                    ""$type"": ""Zad2Serializer.ObjectModel.C, Zad2Serializer"",
                                                                    ""Name"": ""Michał"",
                                                                    ""LastName"": ""Karbowany"",
                                                                    ""Number"": 5321,
                                                                    ""Date"": ""2020-01-02T00:00:00"",
                                                                    ""ObjA"": {
                                                                          ""$id"": ""3"",
                                                                          ""$type"": ""Zad2Serializer.ObjectModel.A, Zad2Serializer"",
                                                                          ""Name"": ""Dominick"",
                                                                          ""LastName"": ""Carski"",
                                                                          ""Number"": 2137,
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
        public void CObjSerializationTest()
        {
            string fileName = "CSerializationTest.json";
            JSONSerialization<C> serializer = new JSONSerialization<C>(fileName, c);
            serializer.serialize();

            string serializedContent = File.ReadAllText(fileName);
            JObject targetJObject = JsonConvert.DeserializeObject<JObject>(@"{   
                                                      ""$id"": ""1"",
                                                      ""$type"": ""Zad2Serializer.ObjectModel.C, Zad2Serializer"",
                                                      ""Name"": ""Michał"",
                                                      ""LastName"": ""Karbowany"",
                                                      ""Number"": 5321,
                                                      ""Date"": ""2020-01-02T00:00:00"",
                                                      ""ObjA"": {
                                                                    ""$id"": ""2"",
                                                                    ""$type"": ""Zad2Serializer.ObjectModel.A, Zad2Serializer"",
                                                                    ""Name"": ""Dominick"",
                                                                    ""LastName"": ""Carski"",
                                                                    ""Number"": 2137,
                                                                    ""Date"": ""2019-12-01T00:00:00"",
                                                                    ""ObjB"": {
                                                                          ""$id"": ""3"",
                                                                          ""$type"": ""Zad2Serializer.ObjectModel.B, Zad2Serializer"",
                                                                          ""Name"": ""Sebaschan"",
                                                                          ""LastName"": ""Kijawiński"",
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
    }
}
