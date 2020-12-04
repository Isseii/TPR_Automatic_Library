using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Zad2Serializer.ObjectModel
{
    public class C : ABC, ISerializable
    {

        public string Name { get; set; }
        public string LastName { get; set; }
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public A ObjA { get; set; }


        [JsonConstructor]
        public C(string name, string lastName, int number, DateTime date, A objA)
        {
            Name = name;
            LastName = lastName;
            Number = number;
            Date = date;
            ObjA = objA;
        }

  
        public C(SerializationInfo info, StreamingContext context)
        {
            Name = (string)info.GetValue("Name", typeof(string));
            LastName = (string)info.GetValue("LastName", typeof(string));
            Number = (int)info.GetValue("Number", typeof(int));
            Date = (DateTime)info.GetValue("Date", typeof(DateTime));
            ObjA = (A)info.GetValue("ObjA", typeof(A));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name);
            info.AddValue("LastName", LastName);
            info.AddValue("Number", Number);
            info.AddValue("Date", Date);
            info.AddValue("ObjA", ObjA, typeof(A));
        }

        public override string ToString()
        {
            return "Name : " + Name + ", Last Name : " + LastName + ", Number : " + Number + ", Date : " + Date.ToString()+ ", Object A";
        }
    }
}
