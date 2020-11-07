using System;

namespace Automatic_Library.Data.ObjectModel.BookEvent
{
    public class Rent : BookEvent
    {
        public Rent(BookCopy book, Reader reader, DateTime rentDate) : base(book, reader, rentDate)
        {
        }
    }
}
