using System;
using System.Collections.Generic;
using System.Text;

namespace Automatic_Library
{
    class BookState
    {
        private BookDescription book;
        public enum Availability
        {
            Available = 0,
            Unavailable = 1,
        }
        private DateTime purchaseDate;
        private Guid id;
        private Availability state;

        public Availability State
        {
            get { return this.state; }
            set { this.state = value; }
        }

        public Guid Id
        {
            get { return this.id; }
        }

        public DateTime PurchaseDate
        {
            get { return this.purchaseDate; }
        }

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




        /*   public BookDescription Book
           {
               get { return this.book.}
           }*/




    }
}
