using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Automatic_Library.Data;
using LibraryTest.DataFiller;
using Automatic_Library.Data.DataPopulator;

namespace LibraryTest.LogicTests
{
    [TestClass()]
    public class LogicTests
    {
        AbstractDataRepository repository;
        [TestInitialize()]
        public void SetUp()
        {
            repository = new DataRepository();
            Populator populator = new Populator();
            DataPopulator dataPopulator = new DataPopulator(repository, populator);
            dataPopulator.populate();
        }

        [TestMethod()]
        public void GetAllBookDescriptionsTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void GetAllBookEventsTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void GetAllBookCopiesTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void GetAllReadersTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void isBookDescriptionInDataRepositoryTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void isBookEventInDataRepositoryTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void isBookCopyInDataRepositoryTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void isReaderInDataRepositoryTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void ReaderBookEventsTest()
        {
            throw new NotImplementedException();
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