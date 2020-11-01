using System;

namespace Automatic_Library
{
    public class Reader
    {
        public string Name { get;  set; }
        public string LastName { get; set; }

        private Guid id;
        public string Id
        {
            get { return id.ToString(); }
        }

        public Reader(string name, string lastName, Guid id)
        {
            this.Name = name;
            this.LastName = lastName;
            this.id = id;
        }

        public Reader(string name, string lastName)
        {
            this.Name = name;
            this.LastName = lastName;
            this.id = Guid.NewGuid();
        }


    }
}
