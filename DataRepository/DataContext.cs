using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Automatic_Library
{
    class DataContext
    {
        public List<Reader> readers;
        public Dictionary<int, BookDescription> bookDescriptions;
        public ObservableCollection<Rent> rents;    //TODO MAKE USE OF OBSERVABLE COLLECTION 
        public List<BookCopy> bookStates;
    }
}
