using System;

namespace Automatic_Library
{
    class Rent
    {
        public DateTime ReturnDate { get; set; }
        public DateTime RentalDate { get; set; }
        public Reader Reader { get; set; }
        public Guid Id { get; set; }

        public BookCopy Book { get; set; }
        public Rent(BookCopy book, Reader reader, DateTime rentalDate)
        {
            this.Book = book;
            this.Reader = reader;
            this.RentalDate = rentalDate;
            this.ReturnDate = default(DateTime);
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
                return (this.Id == ((Rent)obj).Id);
            }
        }

    }
}
