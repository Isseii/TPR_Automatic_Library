using System;
using System.Collections.Generic;
using Automatic_Library.Data.ObjectModel;
using Automatic_Library.Data.ObjectModel.BookEvent;

namespace Automatic_Library.Logic
{
    public interface IDataService
    {
        void AddBookCopy(string title, string author, string publisher, string isbn);
        void AddBookDescription(string title, string author, string publisher);
        void AddReader(string name, string lastName);
        IEnumerable<BookEvent> BookEventsBetweenDates(DateTime start, DateTime end);
        void DeleteBookCopy(string isbn);
        void DeleteBookDescription(string title);
        void DeleteBookEvent(BookEvent bookEvent);
        void DeleteReader(string name, string lastName);
        IEnumerable<BookCopy> GetAllBookCopies();
        IEnumerable<KeyValuePair<string, BookDescription>> GetAllBookDescriptions();
        IEnumerable<BookEvent> GetAllBookEvents();
        IEnumerable<Reader> GetAllReaders();
        bool isBookCopyInDataRepository(BookCopy bookCopy);
        bool isBookDescriptionInDataRepository(BookDescription bookDescription);
        bool isBookEventInDataRepository(BookEvent bookEvent);
        bool isReaderInDataRepository(string name, string lastName);
        IEnumerable<BookEvent> ReaderBookEvents(string name, string lastName);
        void RentBook(Reader reader, BookCopy bookCopy);
        void ReturnBook(Reader reader, BookCopy bookCopy);
    }
}