using System;

namespace Automatic_Library.Data.ObjectModel
{
    public class BookCopy
    {
        public enum Availability
        {
            Available = 0,
            Unavailable = 1,
        }

        public Availability State { get; set; }
        public DateTime PurchaseDate { get; set; }
        public BookDescription Book { get; set; }
        public String Isbn { get; set; }

        public BookCopy(BookDescription book, DateTime purchaseDate, String isbn)
        {
            this.Isbn = isbn;
            this.Book = book;
            this.PurchaseDate = purchaseDate;
            this.State = Availability.Available;
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            var tmp = (BookCopy)obj;


            if (tmp.Isbn == this.Isbn){
                return true;
            }

            return false;
        }
    }
}
