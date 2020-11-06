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
        public ObservableCollection<BookEvent> BookEvents;    //TODO MAKE USE OF OBSERVABLE COLLECTION 
        public List<BookCopy> BookCopies;
    }
}
