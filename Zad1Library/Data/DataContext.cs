using System.Collections.Generic;
using System.Collections.ObjectModel;
using Automatic_Library.Data.ObjectModel;
using Automatic_Library.Data.ObjectModel.BookEvent;

namespace Automatic_Library.Data
{
    public class DataContext
    {
        public List<Reader> Readers;
        public Dictionary<string, BookDescription> BookDescriptions;
        public ObservableCollection<BookEvent> BookEvents;    
        public List<BookCopy> BookCopies;

        public DataContext()
        {
            Readers = new List<Reader>();
            BookDescriptions = new Dictionary<string, BookDescription>();
            BookEvents = new ObservableCollection<BookEvent>();
            BookCopies = new List<BookCopy>();
        }
    }
}
