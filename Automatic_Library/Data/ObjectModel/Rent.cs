using System;

namespace Automatic_Library.Data.ObjectModel
{
    class Rent
    {
        public DateTime ReturnDate { get; set; }
        public DateTime RentalDate { get; set; }
        public Reader Reader { get; set; }
        public BookCopy Book { get; set; }

        public Rent(BookCopy book, Reader reader, DateTime rentalDate)
        {
            this.Book = book;
            this.Reader = reader;
            this.RentalDate = rentalDate;
            this.ReturnDate = default(DateTime);
        }

    }
}
