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

        public BookCopy(BookDescription book, DateTime purchaseDate)
        {
            this.Book = book;
            this.PurchaseDate = purchaseDate;
            this.State = Availability.Available;
        }

    }
}
