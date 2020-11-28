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
    public class CustomSerializerTest
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
        public void AObjCustomSerializationTest()
        {
            string fileName = "ACustomSerializationTest.txt";
            CustomSerialization<A> tmp = new CustomSerialization<A>(fileName, a);
            tmp.Serialize();

            string serialized = File.ReadAllText(fileName);

            Assert.AreEqual("{Zad2Serializer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null|Zad2Serializer.ObjectModel.A|1}" + "\n" +
                "[System.String|Name|Dominick][System.String|LastName|Carski][System.Int32|Number|2137][System.DateTime|Date|12/01/2019][Zad2Serializer.ObjectModel.B|ObjB|ref2]" + "\n" +
                "{Zad2Serializer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null|Zad2Serializer.ObjectModel.B|2}" + "\n" +
                "[System.String|Name|Sebaschan][System.String|LastName|Kijawiński][System.Int32|Number|9669][System.DateTime|Date|10/01/2019][Zad2Serializer.ObjectModel.C|ObjC|ref3]" + "\n" +
                "{Zad2Serializer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null|Zad2Serializer.ObjectModel.C|3}" + "\n" +
                "[System.String|Name|Michał][System.String|LastName|Karbowany][System.Int32|Number|5321][System.DateTime|Date|01/02/2020][Zad2Serializer.ObjectModel.A|ObjA|ref1]" + "\n", serialized);

        }

        [TestMethod]
        public void BObjCustomSerializationTest()
        {
            string fileName = "BCustomSerializationTest.txt";
            CustomSerialization<B> tmp = new CustomSerialization<B>(fileName, b);
            tmp.Serialize();

            string serialized = File.ReadAllText(fileName);

            Assert.AreEqual("{Zad2Serializer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null|Zad2Serializer.ObjectModel.B|1}" + "\n" +
                "[System.String|Name|Sebaschan][System.String|LastName|Kijawiński][System.Int32|Number|9669][System.DateTime|Date|10/01/2019][Zad2Serializer.ObjectModel.C|ObjC|ref2]" + "\n" +
                "{Zad2Serializer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null|Zad2Serializer.ObjectModel.C|2}" + "\n" +
                "[System.String|Name|Michał][System.String|LastName|Karbowany][System.Int32|Number|5321][System.DateTime|Date|01/02/2020][Zad2Serializer.ObjectModel.A|ObjA|ref3]" + "\n" +
                "{Zad2Serializer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null|Zad2Serializer.ObjectModel.A|3}" + "\n" +
                "[System.String|Name|Dominick][System.String|LastName|Carski][System.Int32|Number|2137][System.DateTime|Date|12/01/2019][Zad2Serializer.ObjectModel.B|ObjB|ref1]" + "\n", serialized);

        }

        [TestMethod]
        public void CObjCustomSerializationTest()
        {
            string fileName = "CCustomSerializationTest.txt";
            CustomSerialization<C> tmp = new CustomSerialization<C>(fileName, c);
            tmp.Serialize();

            string serialized = File.ReadAllText(fileName);

            Assert.AreEqual("{Zad2Serializer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null|Zad2Serializer.ObjectModel.C|1}" + "\n" +
                "[System.String|Name|Michał][System.String|LastName|Karbowany][System.Int32|Number|5321][System.DateTime|Date|01/02/2020][Zad2Serializer.ObjectModel.A|ObjA|ref2]" + "\n" +
                "{Zad2Serializer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null|Zad2Serializer.ObjectModel.A|2}" + "\n" +
                "[System.String|Name|Dominick][System.String|LastName|Carski][System.Int32|Number|2137][System.DateTime|Date|12/01/2019][Zad2Serializer.ObjectModel.B|ObjB|ref3]" + "\n" +
                "{Zad2Serializer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null|Zad2Serializer.ObjectModel.B|3}" + "\n" +
                "[System.String|Name|Sebaschan][System.String|LastName|Kijawiński][System.Int32|Number|9669][System.DateTime|Date|10/01/2019][Zad2Serializer.ObjectModel.C|ObjC|ref1]" + "\n", serialized);

        }


        [TestMethod]
        public void AObjCustomDserializationTest()
        {
            string fileName = "ACustomDeserializationTest.txt";
            CustomSerialization<A> tmp = new CustomSerialization<A>(fileName, a);
            tmp.Serialize();

            CustomSerialization<A> tmpDes = new CustomSerialization<A>(fileName, a);
            A desResult = tmpDes.Deserialize();

            Assert.AreEqual(desResult.Name, a.Name);
            Assert.AreEqual(desResult.LastName, a.LastName);
            Assert.AreEqual(desResult.Number, a.Number);
            Assert.AreEqual(desResult.Date, a.Date);

        }


        [TestMethod]
        public void BObjCustomDserializationTest()
        {
            string fileName = "BCustomDeserializationTest.txt";
            CustomSerialization<B> tmp = new CustomSerialization<B>(fileName, b);
            tmp.Serialize();

            CustomSerialization<B> tmpDes = new CustomSerialization<B>(fileName, b);
            B desResult = tmpDes.Deserialize();

            Assert.AreEqual(desResult.Name, b.Name);
            Assert.AreEqual(desResult.LastName, b.LastName);
            Assert.AreEqual(desResult.Number, b.Number);
            Assert.AreEqual(desResult.Date, b.Date);

        }


        [TestMethod]
        public void CObjCustomDserializationTest()
        {
            string fileName = "CCustomDeserializationTest.txt";
            CustomSerialization<C> tmp = new CustomSerialization<C>(fileName, c);
            tmp.Serialize();

            CustomSerialization<C> tmpDes = new CustomSerialization<C>(fileName, c);
            C desResult = tmpDes.Deserialize();

            Assert.AreEqual(desResult.Name, c.Name);
            Assert.AreEqual(desResult.LastName, c.LastName);
            Assert.AreEqual(desResult.Number, c.Number);
            Assert.AreEqual(desResult.Date, c.Date);

        }

    }
}
