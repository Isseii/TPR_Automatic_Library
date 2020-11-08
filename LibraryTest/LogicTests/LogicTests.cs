using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Automatic_Library.Data;
using LibraryTest.DataFiller;
using Automatic_Library.Data.DataPopulator;
using Automatic_Library.Logic;
using Automatic_Library.Data.ObjectModel.BookEvent;
using System.Collections.Generic;
using System.Linq;
using Automatic_Library.Data.ObjectModel;

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

            dataEvents = data.BookEvents.Where(y => y.Equals(x)).ToList() ;
            serviceEvents = dataService.ReaderBookEvents(x.Name, x.LastName).ToList();

            CollectionAssert.AreEquivalent(dataEvents, serviceEvents);
        }

        [TestMethod()]
        public void BookEventsBetweenDatesTest()
        {
            var dateStart = new DateTime();
            var dateEnd = new DateTime();
            var collection1 = dataService.BookEventsBetweenDates(dateStart, dateEnd).ToList();
            var collection2 = data.BookEvents.Where(x => x.EventTime >= dateStart && x.EventTime <= dateEnd).ToList();

            CollectionAssert.AreEquivalent(collection1, collection2);
        }

        [TestMethod()]
        public void AddBookCopyTest()
        {
            var counter = dataService.GetAllBookCopies().Count();
            dataService.AddBookCopy("Mein Kampf", "Adolf Hitler", "Verlag Franz Eher Nachfolger", "133213723121");
            Assert.AreEqual(counter + 1, dataService.GetAllBookCopies().Count());
        }

        [TestMethod()]
        public void AddBookDescriptionTest()
        {
            var counter = dataService.GetAllBookDescriptions().Count();
            dataService.AddBookDescription("Kamień","Adam Nie","Wiadomo");
            Assert.AreEqual(counter + 1, dataService.GetAllBookDescriptions().Count());
        }

        [TestMethod()]
        public void RentBookTest()
        {
            Reader reader = dataService.GetAllReaders().First();
            BookCopy bookCopy = dataService.GetAllBookCopies().First();
            Assert.AreEqual(bookCopy.State, BookCopy.Availability.Available);

            var counter = dataService.GetAllBookEvents().Count();

            dataService.RentBook(reader, bookCopy);
            Assert.AreEqual(bookCopy.State, BookCopy.Availability.Unavailable);
            Assert.AreEqual(counter + 1, dataService.GetAllBookEvents().Count());
        }

        [TestMethod()]
        public void ReturnBookTest()
        {
            Reader reader = dataService.GetAllReaders().First();
            BookCopy bookCopy = dataService.GetAllBookCopies().Last();
            Assert.AreEqual(bookCopy.State, BookCopy.Availability.Unavailable);

            var counter = dataService.GetAllBookEvents().Count();

            dataService.ReturnBook(reader, bookCopy);
            Assert.AreEqual(bookCopy.State, BookCopy.Availability.Available);
            Assert.AreEqual(counter + 1, dataService.GetAllBookEvents().Count());
        }

        [TestMethod()]
        public void AddReaderTest()
        {
            var counter = dataService.GetAllReaders().Count();
            dataService.AddReader("Kamil", "Putout");
            Assert.AreEqual(counter + 1, dataService.GetAllReaders().Count());
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