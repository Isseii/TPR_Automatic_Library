using System;
using System.Collections.Generic;
using System.Text;
using Automatic_Library.Data.ObjectModel;

namespace Automatic_Library.Data
{
    abstract class AbstractDataRepository : IDataRepositoryBookDescription, IDataRepositoryReader, IDataRepositoryBookCopy, IDataRepositoryRent
    {
        public abstract void AddBookCopy(ref BookCopy bookCopy);
        public abstract void AddBookDescription(ref BookDescription bookDescription);
        public abstract void AddReader(ref Reader reader);
        public abstract void AddRent(ref Rent rent);
        public abstract void DeleteBookCopy(ref BookCopy bookCopy);
        public abstract void DeleteBookDescription(ref BookDescription bookDescription);
        public abstract void DeleteReader(ref Reader reader);
        public abstract void DeleteRent(ref Rent rent);
        public abstract IEnumerable<BookCopy> GetAllBookCopies();
        public abstract IEnumerable<BookDescription> GetAllBookDescriptions();
        public abstract IEnumerable<Reader> GetAllReaders();
        public abstract IEnumerable<Rent> GetAllRents();
        public abstract BookCopy GetBookCopy(int i);
        public abstract BookDescription GetBookDescription(string title);
        public abstract Reader GetReader(int i);
        public abstract Rent GetRent(int i);
    }
}
