using System;
using System.Collections.Generic;
using System.Linq;
using Automatic_Library.Data;
using Automatic_Library.Data.ObjectModel;
using Automatic_Library.Data.ObjectModel.BookEvent;

namespace Automatic_Library.Logic
{
    public class DataService : IDataService
    {
        private AbstractDataRepository _dataRepository;

        public IEnumerable<KeyValuePair<string, BookDescription>> GetAllBookDescriptions()
        {
            return _dataRepository.GetAllBookDescriptions();
        }

        public IEnumerable<BookEvent> GetAllBookEvents()
        {
            return _dataRepository.GetAllBookEvents();
        }

        public IEnumerable<BookCopy> GetAllBookCopies()
        {
            return _dataRepository.GetAllBookCopies();
        }

        public IEnumerable<Reader> GetAllReaders()
        {
            return _dataRepository.GetAllReaders();
        }

        public bool isBookDescriptionInDataRepository(BookDescription bookDescription)
        {
            return GetAllBookDescriptions().Where(x => x.Equals(bookDescription)).Count() != 0;
        }

        public bool isBookEventInDataRepository(BookEvent bookEvent)
        {
            return GetAllBookEvents().Where(x => x.Equals(bookEvent)).Count() != 0;
        }
        public bool isBookCopyInDataRepository(BookCopy bookCopy)
        {
            return GetAllBookCopies().Where(x => x.Equals(bookCopy)).Count() != 0;
        }
        public bool isReaderInDataRepository(string name, string lastName)
        {
            var reader = new Reader(name, lastName);
            return GetAllReaders().Where(x => x.Equals(reader)).Count() != 0;
        }

        public IEnumerable<BookEvent> ReaderBookEvents(string name, string lastName)
        {
            var reader = new Reader(name, lastName);
            return _dataRepository.GetAllBookEvents().Where(x => x.Reader == reader);
        }

        public IEnumerable<BookEvent> BookEventsBetweenDates(DateTime start, DateTime end)
        {
            return GetAllBookEvents().Where(x => x.EventTime >= start && x.EventTime <= end);
        }

        public void AddBookCopy(string title, string author, string publisher, string isbn)
        {
            var bookDescription = new BookDescription(title, author, publisher);
            var bookCopy = new BookCopy(bookDescription, DateTime.Now, isbn);
            _dataRepository.AddBookCopy(bookCopy);
        }

        public void AddBookDescription(string title, string author, string publisher)
        {
            var bookDescription = new BookDescription(title, author, publisher);
            _dataRepository.AddBookDescription(bookDescription);
        }

        public void RentBook(Reader reader, BookCopy bookCopy)
        {
            var rent = new Rent(bookCopy, reader, DateTime.Now);
            _dataRepository.AddBookEvent(rent);
        }

        public void ReturnBook(Reader reader, BookCopy bookCopy)
        {
            var returnBook = new Return(bookCopy, reader, DateTime.Now);
            _dataRepository.AddBookEvent(returnBook);
        }

        public void AddReader(string name, string lastName)
        {
            var reader = new Reader(name, lastName);
            _dataRepository.AddReader(reader);
        }

        public void DeleteBookCopy(string isbn)
        {
            foreach (var bookCopy in _dataRepository.GetAllBookCopies())
            {
                if (bookCopy.Isbn.Equals(isbn))
                {
                    _dataRepository.DeleteBookCopy(bookCopy);
                }
            }
        }

        public void DeleteBookDescription(string title)
        {
            var bookDescription = _dataRepository.GetBookDescription(title);
            _dataRepository.DeleteBookDescription(bookDescription);
        }

        public void DeleteReader(string name, string lastName)
        {
            var reader = new Reader(name, lastName);
            _dataRepository.DeleteReader(reader);
        }

        public void DeleteBookEvent(BookEvent bookEvent)
        {
            _dataRepository.DeleteBookEvent(bookEvent);
        }

    }
}
