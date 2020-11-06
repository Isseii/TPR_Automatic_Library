using System;
using System.Collections.Generic;
using System.Text;
using Automatic_Library.Data.ObjectModel;
using Automatic_Library.Data.ObjectModel.BookEvent;

namespace Automatic_Library.Data
{
    abstract class AbstractDataRepository : IDataRepositoryBookDescription, IDataRepositoryReader, IDataRepositoryBookCopy, IDataRepositoryBookEvent
    {
        public abstract void AddBookCopy(ref BookCopy bookCopy);
        public abstract void AddBookDescription(ref BookDescription bookDescription);
        public abstract void AddReader(ref Reader reader);
        public abstract void AddBookEvent(ref ObjectModel.BookEvent.BookEvent bookEvent);
        public abstract void DeleteBookCopy(ref BookCopy bookCopy);
        public abstract void DeleteBookDescription(ref BookDescription bookDescription);
        public abstract void DeleteReader(ref Reader reader);
        public abstract void DeleteBookEvent(ref ObjectModel.BookEvent.BookEvent bookEvent);
        public abstract IEnumerable<BookCopy> GetAllBookCopies();
        public abstract IEnumerable<BookDescription> GetAllBookDescriptions();
        public abstract IEnumerable<Reader> GetAllReaders();
        public abstract IEnumerable<ObjectModel.BookEvent.BookEvent> GetAllBookEvents();
        public abstract BookCopy GetBookCopy(int i);
        public abstract BookDescription GetBookDescription(string title);
        public abstract Reader GetReader(int i);
        public abstract ObjectModel.BookEvent.BookEvent GetBookEvent(int i);
    }
}
