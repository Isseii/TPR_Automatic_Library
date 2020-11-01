using System;

namespace Automatic_Library
{
    public class Reader
    {
        public string Name { get;  set; }
        public string LastName { get; set; }
        public Guid Id { get; }

        public Reader(string name, string lastName, Guid id)
        {
            this.Name = name;
            this.LastName = lastName;
            this.Id = id;
        }

        public Reader(string name, string lastName)
        {
            this.Name = name;
            this.LastName = lastName;
            this.Id = Guid.NewGuid();
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                return (this.Id == ((Reader)obj).Id);
            }
        }

    }
}
