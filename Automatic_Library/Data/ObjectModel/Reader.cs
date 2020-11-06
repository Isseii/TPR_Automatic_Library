using System;

namespace Automatic_Library.Data.ObjectModel
{
    public class Reader
    {
        public string Name { get;  set; }
        public string LastName { get; set; }

        public Reader(string name, string lastName)
        {
            this.Name = name;
            this.LastName = lastName;
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var tmp = (Reader)obj;
                
            if(tmp.Name == this.Name && tmp.LastName == this.LastName)
            {
                return true;
            }
            return false;
        }
    }
}
