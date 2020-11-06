using System;

namespace Automatic_Library.Data.ObjectModel
{
    public class BookDescription
    {
        public string Title { get;  set; }
        public string Author { get; set; }
        public string Publisher { get; set; }

        public BookDescription(string title, string author, string publisher)
        {
            this.Title = title;
            this.Author = author;
            this.Publisher = publisher;
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            var description = (BookDescription)obj;


            if (this.Title == description.Title && this.Author == description.Author && this.Publisher == description.Publisher)
            {
                return true;
            }

            return false;
          
        }
    }
}
