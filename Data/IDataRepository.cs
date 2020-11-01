using System;
using System.Collections.Generic;

namespace Automatic_Library
{
    interface IDataRepositoryBookDescription
    {
        void AddBookDescription(BookDescription bookDescription);
        BookDescription GetBookDescription(Guid id);
        IEnumerable<BookDescription> GetAllBookDescriptions();
        void DeleteBookDescription(BookDescription bookDescription);
    }


    interface IDataRepositoryReader
    {
        void AddReader(Reader reader);
        Reader GetReader(Guid id);
        IEnumerable<Reader> GetAllReaders();
        void DeleteReader(Reader reader);
    }

    interface IDataRepositoryBookCopy
    {
        void AddBookCopy(BookCopy bookCopy);
        BookCopy GetBookCopy(Guid id);
        IEnumerable<BookCopy> GetAllBookCopies();
        void DeleteBookCopy(BookCopy bookCopy);
    }

    interface IDataRepositoryRent
    {
        void AddRent(Rent rent);
        Rent GetRent(Guid id);
        IEnumerable<Rent> GetAllRents();
        void DeleteRent(Rent rent);
    }



}
