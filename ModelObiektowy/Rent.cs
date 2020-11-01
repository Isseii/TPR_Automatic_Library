using System;

namespace Automatic_Library
{
    class Rent
    {
        public DateTime ReturnDate { get; set; }
        public DateTime RentalDate { get; set; }
        public Reader Reader { get; set; }

        public BookState Book { get; set; }
        public Rent(BookState book, Reader reader, DateTime rentalDate)
        {
            this.Book = book;
            this.Reader = reader;
            this.RentalDate = rentalDate;
            this.ReturnDate = default(DateTime);
        }

    }
}
