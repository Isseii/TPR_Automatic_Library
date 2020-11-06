using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Automatic_Library.Data.ObjectModel;

namespace Automatic_Library.Data
{
    class DataContext
    {
        public List<Reader> Readers;
        public Dictionary<Guid, BookDescription> BookDescriptions;
        public ObservableCollection<Rent> Rents;    //TODO MAKE USE OF OBSERVABLE COLLECTION 
        public List<BookCopy> BookCopies;
    }
}
