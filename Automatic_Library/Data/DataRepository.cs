using System;
using System.Collections.Generic;
using System.Linq;
using Automatic_Library.Data.ObjectModel;

namespace Automatic_Library.Data
{
    class DataRepository : IDataRepositoryBookDescription, IDataRepositoryReader, IDataRepositoryBookCopy, IDataRepositoryRent
    {
        private DataContext _dataContext;

        public DataRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

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
            return _dataContext.Readers;
        }

        public IEnumerable<Rent> GetAllRents()
        {
            return _dataContext.Rents;
        }

        public BookCopy GetBookCopy(Guid id)
        {
            return _dataContext.BookCopies.Find(x => x.Id.Equals(id));
        }

        public BookDescription GetBookDescription(Guid id)
        {
            BookDescription bookDescription = null;
             _dataContext.BookDescriptions.TryGetValue(id, out bookDescription);
            return bookDescription;
        }

        public Reader GetReader(Guid id)
        {
            return _dataContext.Readers.Find(x => x.Id.Equals(id));
        }

        public Rent GetRent(Guid id)
        {
            try
            {
                return _dataContext.Rents.Single(x => x.Id.Equals(id));
            }
            catch(Exception e) {}
            return null;
         }
    }
}
