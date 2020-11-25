using System.Collections.Generic;
using Automatic_Library.Data.ObjectModel;
using Automatic_Library.Data.ObjectModel.BookEvent;

namespace Automatic_Library.Data
{
    public abstract class AbstractDataRepository : IDataRepositoryBookDescription, IDataRepositoryReader, IDataRepositoryBookCopy, IDataRepositoryBookEvent
    {
        public abstract void AddBookCopy( BookCopy bookCopy);
        public abstract void AddBookDescription( BookDescription bookDescription);
        public abstract void AddReader( Reader reader);
        public abstract void AddBookEvent( BookEvent bookEvent);
        public abstract void DeleteBookCopy( BookCopy bookCopy);
        public abstract void DeleteBookDescription( BookDescription bookDescription);
        public abstract void DeleteReader( Reader reader);
        public abstract void DeleteBookEvent( BookEvent bookEvent);
        public abstract IEnumerable<BookCopy> GetAllBookCopies();
        public abstract IEnumerable<KeyValuePair<string, BookDescription>> GetAllBookDescriptions();
        public abstract IEnumerable<Reader> GetAllReaders();
        public abstract IEnumerable<BookEvent> GetAllBookEvents();
        public abstract BookCopy GetBookCopy(int i);
        public abstract BookDescription GetBookDescription(string title);
        public abstract Reader GetReader(int i);
        public abstract BookEvent GetBookEvent(int i);
    }
}
