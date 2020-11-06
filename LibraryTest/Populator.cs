using System;
using System.Collections.Generic;
using System.Text;
using Automatic_Library.Data.ObjectModel;
using Automatic_Library.Data.ObjectModel.BookEvent;

namespace Automatic_Library.Data.DataPopulator
{
    class Populator : IPopulateData
    {
        private DataHolder data;

        Populator()
        {
            data = new DataHolder();
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
            return (IEnumerable<BookDescription>)data.BookDescriptions;
        }

        public IEnumerable<Reader> GetReaders()
        {
            return data.Readers;
        }
    }
}
