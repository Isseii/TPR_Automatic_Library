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
            var x = bookCopy ?? throw new ArgumentNullException();
            if(_dataContext.BookCopies.Find(y => y.Equals(x)) == null)
            {
                _dataContext.BookCopies.Add(x);
            }
        }

        public override void AddBookDescription( BookDescription bookDescription)
        {
            var x = bookDescription ?? throw new ArgumentNullException();
           if (_dataContext.BookDescriptions.Where(y => y.Equals(x)).Count() == 0 )
             {
                _dataContext.BookDescriptions.Add(x.Title, x);
            }
        }

        public override void AddReader( Reader reader)
        {
            var y = reader ?? throw new ArgumentNullException();
            if (_dataContext.Readers.Find(x => x.Equals(y)) == null)
            {
                _dataContext.Readers.Add(y);
            }
        }

        public override void AddBookEvent( BookEvent bookEvent)
        {
            var y = bookEvent ?? throw new ArgumentNullException();
            if (_dataContext.BookEvents.Where(x => x.Equals(y)).Count() == 0)
            {
                _dataContext.BookEvents.Add(y);
            }
        }

        public override void DeleteBookCopy( BookCopy bookCopy)
        {
            _dataContext.BookCopies.Remove(bookCopy ?? throw new ArgumentNullException());
        }

        public override void DeleteBookDescription( BookDescription bookDescription)
        {
            var x = bookDescription ?? throw new ArgumentNullException();
            _dataContext.BookDescriptions.Remove(x.Title);
        }

        public override void DeleteReader( Reader reader)
        {
            _dataContext.Readers.Remove(reader ?? throw new ArgumentNullException());
        }

        public override void DeleteBookEvent( BookEvent bookEvent)
        {
            _dataContext.BookEvents.Remove(bookEvent ?? throw new ArgumentNullException());
        }

        public override IEnumerable<BookCopy> GetAllBookCopies()
        {
            return _dataContext.BookCopies;
        }

        public override IEnumerable<KeyValuePair<string, BookDescription>> GetAllBookDescriptions()
        {
            return _dataContext.BookDescriptions;
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
