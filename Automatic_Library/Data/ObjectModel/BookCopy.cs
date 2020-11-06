using System;

namespace Automatic_Library.Data.ObjectModel
{
    class BookCopy
    {
        public enum Availability
        {
            Available = 0,
            Unavailable = 1,
        }

        public Availability State { get; set; }
        public DateTime PurchaseDate { get; set; }
        public BookDescription Book { get; set; }
        public Guid Id { get; }

        public BookCopy(BookDescription book, DateTime purchaseDate, Guid id, Availability state)
        {
            this.Book = book;
            this.PurchaseDate = purchaseDate;
            this.Id = id;
            this.State = state;
        }

        public BookCopy(BookDescription book, DateTime purchaseDate, Availability state)
        {
            this.Book = book;
            this.PurchaseDate = purchaseDate;
            this.State = state;
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
                return (this.Id == ((BookCopy)obj).Id);
            }
        }
    }
}
