using System;
using System.Collections.Generic;
using Automatic_Library.Data.ObjectModel;

namespace Automatic_Library.Data
{
    interface IDataRepositoryBookDescription
    {
        void AddBookDescription(ref BookDescription bookDescription);
        BookDescription GetBookDescription(string title);
        IEnumerable<BookDescription> GetAllBookDescriptions();
        void DeleteBookDescription(ref BookDescription bookDescription);
    }

    interface IDataRepositoryReader
    {
        void AddReader(ref Reader reader);
        Reader GetReader(int i);
        IEnumerable<Reader> GetAllReaders();
        void DeleteReader(ref Reader reader);
    }

    interface IDataRepositoryBookCopy
    {
        void AddBookCopy(ref BookCopy bookCopy);
        BookCopy GetBookCopy(int i);
        IEnumerable<BookCopy> GetAllBookCopies();
        void DeleteBookCopy(ref BookCopy bookCopy);
    }

    interface IDataRepositoryRent
    {
        void AddRent(ref Rent rent);
        Rent GetRent(int i);
        IEnumerable<Rent> GetAllRents();
        void DeleteRent(ref Rent rent);
    }

}
