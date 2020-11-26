using System;
using System.Runtime.Serialization;

namespace Zad2Serializer.ObjectModel
{
    public class A : ISerializable
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public B ObjB { get; set; }

        public A(string name, string lastName, int number, DateTime date, B objB)
        {
            Name = name;
            LastName = lastName;
            Number = number;
            Date = date;
            ObjB = objB;
        }


        public A(SerializationInfo info, StreamingContext context)
        {
            Name = (string)info.GetValue("Name", typeof(string));
            LastName = (string)info.GetValue("LastName", typeof(string));
            Number = (int)info.GetValue("Number", typeof(int));
            Date = (DateTime)info.GetValue("Date", typeof(DateTime));
            ObjB = (B)info.GetValue("ObjB", typeof(B));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name);
            info.AddValue("LastName", LastName);
            info.AddValue("Number", Number);
            info.AddValue("Date", Date);
            info.AddValue("ObjB", ObjB, typeof(B));
        }
    }
}
