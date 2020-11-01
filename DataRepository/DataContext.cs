using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Automatic_Library
{
    class DataContext
    {
        public List<Reader> Readers;
        public Dictionary<Guid, BookDescription> BookDescriptions;
        public ObservableCollection<Rent> Rents;    //TODO MAKE USE OF OBSERVABLE COLLECTION 
        public List<BookCopy> BookCopies;
    }
}
