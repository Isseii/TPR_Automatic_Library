using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Automatic_Library.Data;
using LibraryTest.DataFiller;
using Automatic_Library.Data.DataPopulator;
using Automatic_Library.Logic;
using Automatic_Library.Data.ObjectModel;
using Automatic_Library.Data.ObjectModel;
using Automatic_Library.Data.ObjectModel.BookEvent;
using System.Collections.Generic;
using System.Linq;

namespace LibraryTest.LogicTests
{
    [TestClass()]
    public class LogicTests
    {
        IDataService dataService;
        DataHolder data = new DataHolder();

        [TestInitialize()]
        public void SetUp()
        {
            var repository = new DataRepository();
            Populator populator = new Populator();
            DataPopulator dataPopulator = new DataPopulator(repository, populator);
            dataPopulator.populate();
            dataService = new DataService(repository);
        }

        [TestMethod()]
        public void GetAllBookDescriptionsTest()
        {
            int i = 0;
            foreach ( var bookDescription in dataService.GetAllBookDescriptions())
            {
                Assert.AreEqual(bookDescription.Value, data.BookDescriptions[i]);
                i++;
            }
        }

        [TestMethod()]
        public void GetAllBookEventsTest()
        {
            int i = 0;
            foreach (var item in dataService.GetAllBookEvents())
            {
                Assert.AreEqual(item, data.BookEvents[i]);
                i++;
            }
        }

        [TestMethod()]
        public void GetAllBookCopiesTest()
        {
            int i = 0;
            foreach (var item in dataService.GetAllBookCopies())
            {
                Assert.AreEqual(item, data.BookCopies[i]);
                i++;
            }
        }

        [TestMethod()]
        public void GetAllReadersTest()
        {
            int i = 0;
            foreach (var item in dataService.GetAllReaders())
            {
                Assert.AreEqual(item, data.Readers[i]);
                i++;
            }
        }

        [TestMethod()]
        public void isBookDescriptionInDataRepositoryTest()
        {
            foreach (var item in data.BookDescriptions )
            {
                Assert.IsTrue(dataService.isBookDescriptionInDataRepository(item));
            }
        }

        [TestMethod()]
        public void isBookEventInDataRepositoryTest()
        {
            foreach (var item in data.BookEvents )
            {
                Assert.IsTrue(dataService.isBookEventInDataRepository(item));
            }
        }

        [TestMethod()]
        public void isBookCopyInDataRepositoryTest()
        {
            foreach (var item in data.BookCopies)
            {
                Assert.IsTrue(dataService.isBookCopyInDataRepository(item));
            }
        }

        [TestMethod()]
        public void isReaderInDataRepositoryTest()
        {
            foreach (var item in data.Readers)
            {
                Assert.IsTrue(dataService.isReaderInDataRepository(item.Name, item.LastName));
            }
        }

        [TestMethod()]
        public void ReaderBookEventsTest()
        {
            var x = data.Readers[0];
            List<BookEvent> dataEvents = new List<BookEvent>();
            List<BookEvent> serviceEvents = new List<BookEvent>();

            dataEvents = data.BookEvents.Where(y => y.Equals(x)).ToList<BookEvent>() ;
            serviceEvents = dataService.ReaderBookEvents(x.Name, x.LastName).ToList<BookEvent>();

            for (int i = 0; i < dataEvents.Count(); i++) 
            {
                Assert.AreEqual(dataEvents[i], serviceEvents[i]);
            }
        }

        [TestMethod()]
        public void BookEventsBetweenDatesTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void AddBookCopyTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void AddBookDescriptionTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void RentBookTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void ReturnBookTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void AddReaderTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void DeleteBookCopyTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void DeleteBookDescriptionTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void DeleteReaderTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void DeleteBookEventTest()
        {
            throw new NotImplementedException();
        }
    }
}