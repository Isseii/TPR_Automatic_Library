using System;
using System.Collections.Generic;
using System.Linq;
using Automatic_Library.Data.ObjectModel;

namespace Automatic_Library.Data
{
    class DataRepository : AbstractDataRepository
    {
        private DataContext _dataContext;

        public DataRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public override void AddBookCopy(ref BookCopy bookCopy)
        {
            _dataContext.BookCopies.Add(bookCopy);
        }

        public override void AddBookDescription(ref BookDescription bookDescription)
        {
            _dataContext.BookDescriptions.Add(bookDescription.Title, bookDescription);
        }

        public override void AddReader(ref Reader reader)
        {
            _dataContext.Readers.Add(reader);
        }

        public override void AddRent(ref Rent rent)
        {
            _dataContext.Rents.Add(rent);
        }

        public override void DeleteBookCopy(ref BookCopy bookCopy)
        {
            _dataContext.BookCopies.Remove(bookCopy);
        }

        public override void DeleteBookDescription(ref BookDescription bookDescription)
        {
            _dataContext.BookDescriptions.Remove(bookDescription.Title);
        }

        public override void DeleteReader(ref Reader reader)
        {
            _dataContext.Readers.Remove(reader);
        }

        public override void DeleteRent(ref Rent rent)
        {
            _dataContext.Rents.Remove(rent);
        }

        public override IEnumerable<BookCopy> GetAllBookCopies()
        {
            return _dataContext.BookCopies;
        }

        public override IEnumerable<BookDescription> GetAllBookDescriptions()
        {
            return (IEnumerable<BookDescription>)_dataContext.BookDescriptions;
        }

        public override IEnumerable<Reader> GetAllReaders()
        {
            return _dataContext.Readers;
        }

        public override IEnumerable<Rent> GetAllRents()
        {
            return _dataContext.Rents;
        }

        public override BookCopy GetBookCopy(int i)
        {
            return _dataContext.BookCopies[i];
        }

        public override BookDescription GetBookDescription(string title)
        {
            BookDescription bookDescription = null;
             _dataContext.BookDescriptions.TryGetValue(title, out bookDescription);
            return bookDescription;
        }

        public override Reader GetReader(int i)
        {
            return _dataContext.Readers[i];
        }

        public override Rent GetRent(int i)
        {
            return _dataContext.Rents[i];
        }
    }
}
