using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Zad2Serializer.ObjectModel
{
    public class B : ISerializable
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public C ObjC { get; set; }


        [JsonConstructor]
        public B(string name, string lastName, int number, DateTime date, C objC)
        {
            Name = name;
            LastName = lastName;
            Number = number;
            Date = date;
            ObjC = objC;
        }

 
        public B(SerializationInfo info, StreamingContext context)
        {
            Name = (string)info.GetValue("Name", typeof(string));
            LastName = (string)info.GetValue("LastName", typeof(string));
            Number = (int)info.GetValue("Number", typeof(int));
            Date = (DateTime)info.GetValue("Date", typeof(DateTime));
            ObjC = (C)info.GetValue("ObjC", typeof(C));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name);
            info.AddValue("LastName", LastName);
            info.AddValue("Number", Number);
            info.AddValue("Date", Date);
            info.AddValue("ObjC", ObjC, typeof(C));
        }
    }
}
