using System;
using System.Collections.Generic;
using Automatic_Library.Data.ObjectModel;
using Automatic_Library.Data.ObjectModel.BookEvent;

namespace Automatic_Library.Data
{
    interface IDataRepositoryBookDescription
    {
        void AddBookDescription(BookDescription bookDescription);
        BookDescription GetBookDescription(string title);
        IEnumerable<BookDescription> GetAllBookDescriptions();
        void DeleteBookDescription(BookDescription bookDescription);
    }

    interface IDataRepositoryReader
    {
        void AddReader(Reader reader);
        Reader GetReader(int i);
        IEnumerable<Reader> GetAllReaders();
        void DeleteReader(Reader reader);
    }

    interface IDataRepositoryBookCopy
    {
        void AddBookCopy(BookCopy bookCopy);
        BookCopy GetBookCopy(int i);
        IEnumerable<BookCopy> GetAllBookCopies();
        void DeleteBookCopy(BookCopy bookCopy);
    }

    interface IDataRepositoryBookEvent
    {
        void AddBookEvent(BookEvent bookEvent);
        BookEvent GetBookEvent(int i);
        IEnumerable<BookEvent> GetAllBookEvents();
        void DeleteBookEvent( BookEvent bookEvent);
    }

}
