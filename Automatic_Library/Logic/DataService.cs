using System;
using System.Collections.Generic;
using System.Linq;
using Automatic_Library.Data;
using Automatic_Library.Data.ObjectModel;
using Automatic_Library.Data.ObjectModel.BookEvent;

namespace Automatic_Library.Logic
{
    class DataService
    {
        private AbstractDataRepository _dataRepository;
        
        IEnumerable<BookDescription> AllBookDescriptions()
        {
            return _dataRepository.GetAllBookDescriptions();
        }

        IEnumerable<BookEvent> ReaderBookEvents(Reader reader)
        {
            return _dataRepository.GetAllBookEvents().Where(x => x.Reader == reader);
        }

        IEnumerable<BookEvent> BookEventsBetweenDates(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        BookEvent AddBookEvent(BookCopy bookCopy, Reader reader)
        {
            throw new NotImplementedException();
        }
        

    }
}
