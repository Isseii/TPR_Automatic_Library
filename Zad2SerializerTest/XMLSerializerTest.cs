using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zad2Serializer.ObjectModel;
using Zad2Serializer.Serialization;

namespace Zad2SerializerTest
{
    [TestClass]
    public class XMLSerializerTest
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
        public void AObjXMLSerializationTest()
        {
            string fileName = "ASerializationTest.xml";
            XMLSerialization<A> serializer = new XMLSerialization<A>(fileName, a);
            serializer.Serialize();


            string serializedContent = File.ReadAllText(fileName);
            Assert.AreEqual(serializedContent, @"<root xmlns:json=""http://james.newtonking.com/projects/json"" json:id=""1"" json:type=""Zad2Serializer.ObjectModel.A, Zad2Serializer"">
  <Name>Dominik</Name>
  <LastName>Karski</LastName>
  <Number>4124</Number>
  <Date>2019-12-01T00:00:00</Date>
  <ObjB json:id=""2"" json:type=""Zad2Serializer.ObjectModel.B, Zad2Serializer"">
    <Name>Sebastian</Name>
    <LastName>Kujawski</LastName>
    <Number>9669</Number>
    <Date>2019-10-01T00:00:00</Date>
    <ObjC json:id=""3"" json:type=""Zad2Serializer.ObjectModel.C, Zad2Serializer"">
      <Name>Michał</Name>
      <LastName>Kowalski</LastName>
      <Number>5321</Number>
      <Date>2020-01-02T00:00:00</Date>
      <ObjA json:ref=""1"" />
    </ObjC>
  </ObjB>
</root>");

        }


        [TestMethod]
        public void BObjXMLSerializationTest()
        {
            string fileName = "BSerializationTest.xml";
            XMLSerialization<B> serializer = new XMLSerialization<B>(fileName, b);
            serializer.Serialize();

            string serializedContent = File.ReadAllText(fileName);
            Assert.AreEqual(serializedContent, @"<root xmlns:json=""http://james.newtonking.com/projects/json"" json:id=""1"" json:type=""Zad2Serializer.ObjectModel.B, Zad2Serializer"">
  <Name>Sebastian</Name>
  <LastName>Kujawski</LastName>
  <Number>9669</Number>
  <Date>2019-10-01T00:00:00</Date>
  <ObjC json:id=""2"" json:type=""Zad2Serializer.ObjectModel.C, Zad2Serializer"">
    <Name>Michał</Name>
    <LastName>Kowalski</LastName>
    <Number>5321</Number>
    <Date>2020-01-02T00:00:00</Date>
    <ObjA json:id=""3"" json:type=""Zad2Serializer.ObjectModel.A, Zad2Serializer"">
      <Name>Dominik</Name>
      <LastName>Karski</LastName>
      <Number>4124</Number>
      <Date>2019-12-01T00:00:00</Date>
      <ObjB json:ref=""1"" />
    </ObjA>
  </ObjC>
</root>");
        }

        [TestMethod]
        public void CObjXMLSerializationTest()
        {
            string fileName = "CSerializationTest.xml";
            XMLSerialization<C> serializer = new XMLSerialization<C>(fileName, c);
            serializer.Serialize();

            string serializedContent = File.ReadAllText(fileName);

            Assert.AreEqual(serializedContent, @"<root xmlns:json=""http://james.newtonking.com/projects/json"" json:id=""1"" json:type=""Zad2Serializer.ObjectModel.C, Zad2Serializer"">
  <Name>Michał</Name>
  <LastName>Kowalski</LastName>
  <Number>5321</Number>
  <Date>2020-01-02T00:00:00</Date>
  <ObjA json:id=""2"" json:type=""Zad2Serializer.ObjectModel.A, Zad2Serializer"">
    <Name>Dominik</Name>
    <LastName>Karski</LastName>
    <Number>4124</Number>
    <Date>2019-12-01T00:00:00</Date>
    <ObjB json:id=""3"" json:type=""Zad2Serializer.ObjectModel.B, Zad2Serializer"">
      <Name>Sebastian</Name>
      <LastName>Kujawski</LastName>
      <Number>9669</Number>
      <Date>2019-10-01T00:00:00</Date>
      <ObjC json:ref=""1"" />
    </ObjB>
  </ObjA>
</root>");
         
        }


        [TestMethod]
        public void AObjXMLDeserializationTest()
        {
            string fileName = "ADeserializationTest.xml";
            XMLSerialization<A> serializer = new XMLSerialization<A>(fileName, a);
            serializer.Serialize();

            XMLSerialization<A> tmp = new XMLSerialization<A>("ADeserializationTest.xml", a);
            A desResult = tmp.Deserialize();

            Assert.AreEqual(desResult.Name, a.Name);
            Assert.AreEqual(desResult.LastName, a.LastName);
            Assert.AreEqual(desResult.Number, a.Number);
            Assert.AreEqual(desResult.Date, a.Date);
        }

        [TestMethod]
        public void BObjXMLDeserializationTest()
        {
            string fileName = "BDeserializationTest.xml";
            XMLSerialization<B> serializer = new XMLSerialization<B>(fileName, b);
            serializer.Serialize();

            XMLSerialization<B> tmp = new XMLSerialization<B>("BDeserializationTest.xml", b);
            B desResult = tmp.Deserialize();

            Assert.AreEqual(desResult.Name, b.Name);
            Assert.AreEqual(desResult.LastName, b.LastName);
            Assert.AreEqual(desResult.Number, b.Number);
            Assert.AreEqual(desResult.Date, b.Date);
        }

        [TestMethod]
        public void CObjXMLDeserializationTest()
        {
            string fileName = "CDeserializationTest.xml";
            XMLSerialization<C> serializer = new XMLSerialization<C>(fileName, c);
            serializer.Serialize();

            XMLSerialization<C> tmp = new XMLSerialization<C>("CDeserializationTest.xml", c);
            C desResult = tmp.Deserialize();

            Assert.AreEqual(desResult.Name, c.Name);
            Assert.AreEqual(desResult.LastName, c.LastName);
            Assert.AreEqual(desResult.Number, c.Number);
            Assert.AreEqual(desResult.Date, c.Date);
        }

    }
}

