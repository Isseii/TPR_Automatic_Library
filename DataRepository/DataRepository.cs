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
            _dataContext.BookCopies.Add(bookCopy);
        }

        public void AddBookDescription(BookDescription bookDescription)
        {
            _dataContext.BookDescriptions.Add(bookDescription.Id, bookDescription);
        }

        public void AddReader(Reader reader)
        {
            _dataContext.Readers.Add(reader);
        }

        public void AddRent(Rent rent)
        {
            _dataContext.Rents.Add(rent);
        }

        public void DeleteBookCopy(BookCopy bookCopy)
        {
            _dataContext.BookCopies.Remove(bookCopy);
        }

        public void DeleteBookDescription(BookDescription bookDescription)
        {
            _dataContext.BookDescriptions.Remove(bookDescription.Id);
        }

        public void DeleteReader(Reader reader)
        {
            _dataContext.Readers.Remove(reader);
        }

        public void DeleteRent(Rent rent)
        {
            _dataContext.Rents.Remove(rent);
        }

        public IEnumerable<BookCopy> GetAllBookCopies()
        {
            return _dataContext.BookCopies;
        }

        public IEnumerable<BookDescription> GetAllBookDescriptions()
        {
            return (IEnumerable<BookDescription>)_dataContext.BookDescriptions;
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
