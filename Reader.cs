using System;

namespace Automatic_Library
{
    public class Reader
    {
        private string name;
        private string lastName;
        private Guid id;

        public Reader(string name, string lastName, Guid id)
        {
            this.name = name;
            this.lastName = lastName;
            this.id = id;
        }

        public Reader(string name, string lastName)
        {
            this.name = name;
            this.lastName = lastName;
            this.id = Guid.NewGuid();
        }
    }
}
