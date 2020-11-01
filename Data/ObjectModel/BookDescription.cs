using System;

namespace Automatic_Library
{
    class BookDescription
    {
        public string Title { get;  set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public Guid Id { get; }

        public BookDescription(string title, string author, string publisher)
        {
            this.Title = title;
            this.Author = author;
            this.Publisher = publisher;
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
                return (this.Id == ((BookDescription)obj).Id);
            }
        }

    }
}
