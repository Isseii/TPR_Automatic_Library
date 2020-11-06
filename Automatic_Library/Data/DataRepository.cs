using System;
using System.Collections.Generic;
using System.Linq;
using Automatic_Library.Data.ObjectModel;
using Automatic_Library.Data.ObjectModel.BookEvent;

namespace Automatic_Library.Data
{
    public class DataRepository : AbstractDataRepository
    {
        private DataContext _dataContext;

        public DataRepository()
        {
            _dataContext = new DataContext();
        }

        public override void AddBookCopy( BookCopy bookCopy)
        {
            _dataContext.BookCopies.Add(bookCopy);
        }

        public override void AddBookDescription( BookDescription bookDescription)
        {
            _dataContext.BookDescriptions.Add(bookDescription.Title, bookDescription);
        }

        public override void AddReader( Reader reader)
        {
            _dataContext.Readers.Add(reader);
        }

        public override void AddBookEvent( BookEvent bookEvent)
        {
            _dataContext.BookEvents.Add(bookEvent);
        }

        public override void DeleteBookCopy( BookCopy bookCopy)
        {
            _dataContext.BookCopies.Remove(bookCopy);
        }

        public override void DeleteBookDescription( BookDescription bookDescription)
        {
            _dataContext.BookDescriptions.Remove(bookDescription.Title);
        }

        public override void DeleteReader( Reader reader)
        {
            _dataContext.Readers.Remove(reader);
        }

        public override void DeleteBookEvent( BookEvent bookEvent)
        {
            _dataContext.BookEvents.Remove(bookEvent);
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

        public override IEnumerable<ObjectModel.BookEvent.BookEvent> GetAllBookEvents()
        {
            return _dataContext.BookEvents;
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

        public override BookEvent GetBookEvent(int i)
        {
            return _dataContext.BookEvents[i];
        }
    }
}
