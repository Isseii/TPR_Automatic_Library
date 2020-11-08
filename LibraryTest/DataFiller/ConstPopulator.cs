using System.Collections.Generic;
using Automatic_Library.Data.ObjectModel;
using Automatic_Library.Data.ObjectModel.BookEvent;
using Automatic_Library.Data.DataPopulator;


namespace LibraryTest.DataFiller
{
    class ConstPopulator : IPopulateData
    {
        private ConstDataHolder data;

        public ConstPopulator()
        {
            data = new ConstDataHolder();
        }

        public IEnumerable<BookEvent> GetBookEvents()
        {
            return data.BookEvents;
        }

        public IEnumerable<BookCopy> GetBookCopies()
        {
            return data.BookCopies;
        }

        public IEnumerable<BookDescription> GetBookDescriptions()
        {
            return data.BookDescriptions;
        }

        public IEnumerable<Reader> GetReaders()
        {
            return data.Readers;
        }
    }
}
