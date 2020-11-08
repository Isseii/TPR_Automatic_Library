using Automatic_Library.Data.DataPopulator;
using Automatic_Library.Data.ObjectModel;
using Automatic_Library.Data.ObjectModel.BookEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryTest.DataFiller
{
    class RandomPopulator : IPopulateData
    {
        RandomDataHolder randomDataHolder;

        public RandomPopulator()
        {
            this.randomDataHolder = new  RandomDataHolder();
        }

        public IEnumerable<BookCopy> GetBookCopies()
        {
            return randomDataHolder.BookCopies;
        }

        public IEnumerable<BookDescription> GetBookDescriptions()
        {
            return randomDataHolder.BookDescriptions;
        }

        public IEnumerable<BookEvent> GetBookEvents()
        {
            return randomDataHolder.BookEvents ;
        }

        public IEnumerable<Reader> GetReaders()
        {
            return randomDataHolder.Readers;
        }
    }
}
