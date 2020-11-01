using System;
using System.Collections.Generic;
using System.Text;

namespace Automatic_Library
{
    class DataRepository : IDataRepositoryBookDescription, IDataRepositoryReader, IDataRepositoryBookCopy, IDataRepositoryRent
    {
        private DataContext _dataContext;

        public void AddBookCopy(BookCopy bookCopy)
        {
            throw new NotImplementedException();
        }

        public void AddBookDescription(BookDescription bookDescription)
        {
            throw new NotImplementedException();
        }

        public void AddReader(Reader reader)
        {
            throw new NotImplementedException();
        }

        public void AddRent(Rent rent)
        {
            throw new NotImplementedException();
        }

        public void DeleteBookCopy(BookCopy bookCopy)
        {
            throw new NotImplementedException();
        }

        public void DeleteBookDescription(BookDescription bookDescription)
        {
            throw new NotImplementedException();
        }

        public void DeleteReader(Reader reader)
        {
            throw new NotImplementedException();
        }

        public void DeleteRent(Rent rent)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookCopy> GetAllBookCopies()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookDescription> GetAllBookDescriptions()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Reader> GetAllReaders()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Rent> GetAllRents()
        {
            throw new NotImplementedException();
        }

        public BookCopy GetBookCopy(Guid id)
        {
            throw new NotImplementedException();
        }

        public BookDescription GetBookDescription(Guid id)
        {
            throw new NotImplementedException();
        }

        public Reader GetReader(Guid id)
        {
            throw new NotImplementedException();
        }

        public Rent GetRenty(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
