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

    }
}
