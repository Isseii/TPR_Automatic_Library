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

        private BookDescription book;
        private DateTime purchaseDate;
        private Guid id;
        private Availability state;


        public BookState(BookDescription book, DateTime purchaseDate, Guid id, Availability state)
        {
            this.book = book;
            this.purchaseDate = purchaseDate;
            this.id = id;
            this.state = state;
        }

        public BookState(BookDescription book, DateTime purchaseDate, Availability state)
        {
            this.book = book;
            this.purchaseDate = purchaseDate;
            this.state = state;
            this.id = Guid.NewGuid();
        }

        public Availability State
        {
            get { return this.state; }
            set { this.state = value; }
        }

        public string Id
        {
            get { return this.id.ToString(); }
        }

        public DateTime PurchaseDate
        {
            get { return this.purchaseDate; }
        }

        public BookDescription Book
        {
            get { return this.book; }
        }

    }
}
