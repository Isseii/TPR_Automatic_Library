using System;

namespace Automatic_Library
{
    class BookState
    {
        public enum Availability
        {
            Available = 0,
            Unavailable = 1,
        }

        public Availability State { get; set; }
        public DateTime PurchaseDate { get; set; }
        public BookDescription Book { get; set; }

        private Guid id;
        public string Id
        {
            get { return this.id.ToString(); }
        }

        public BookState(BookDescription book, DateTime purchaseDate, Guid id, Availability state)
        {
            this.Book = book;
            this.PurchaseDate = purchaseDate;
            this.id = id;
            this.State = state;
        }

        public BookState(BookDescription book, DateTime purchaseDate, Availability state)
        {
            this.Book = book;
            this.PurchaseDate = purchaseDate;
            this.State = state;
            this.id = Guid.NewGuid();
        }

    }
}
