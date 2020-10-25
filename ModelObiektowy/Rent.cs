using System;

namespace Automatic_Library
{
    class Rent
    {
        private BookState book;
        private Reader reader;
        private DateTime rentalDate;
        private DateTime returnDate;

        public Rent(BookState book, Reader reader, DateTime rentalDate)
        {
            this.book = book;
            this.reader = reader;
            this.rentalDate = rentalDate;
            this.returnDate = default(DateTime);
        }

        public DateTime ReturnDate
        {
            get { return this.returnDate; }
            set { this.returnDate = value; }
        }

        public DateTime RentalDate
        {
            get { return this.rentalDate; }
        }

        public Reader Reader
        {
            get { return this.reader; }
        }

        public BookState Book
        {
            get { return this.book; }
        }

    }
}
