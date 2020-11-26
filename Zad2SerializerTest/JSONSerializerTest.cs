using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zad2Serializer.ObjectModel;
using Zad2Serializer.Serialization;
using System.IO;

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
            A a = new A("Dominick", "Carski", 2137, new DateTime(2019, 12, 1), null);
            B b = new B("Sebaschan", "Kijawiński", 9669, new DateTime(2019, 10, 1), null);
            C c = new C("Michał", "Karbowany", 5321, new DateTime(2020, 1, 2), null);

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
            Assert.AreEqual(serializedContent, @"null");
        }
    }
}
