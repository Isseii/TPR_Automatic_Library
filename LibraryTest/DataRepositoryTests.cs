using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Automatic_Library.Data;
using Automatic_Library.Data.DataPopulator;
using Automatic_Library.Data.ObjectModel;
using System.Linq;

namespace LibraryTest
{
    [TestClass]
    public class DataRepositoryTests
    {
        AbstractDataRepository repository;

        [TestInitialize]
        public void SetUp()
        {
            repository = new DataRepository();
            Populator populator = new Populator();
            DataPopulator dataPopulator = new DataPopulator(repository, populator);
            dataPopulator.populate();
        }

        [TestMethod]
        public void AddTheSameObjectTest()
        {
            Reader reader = new Reader("Dominik", "Karski");
            Assert.AreEqual(repository.GetAllReaders().Count(), 4);
            repository.AddReader(reader);
            Assert.AreNotEqual(repository.GetAllReaders().Count(), 5);

            BookDescription book = new BookDescription("Metro 2033", "Dmitry Glukhovsky", "Insignis");
            var count = repository.GetAllBookDescriptions().Count();
            Assert.AreEqual(count, 4);
            try
            {
                repository.AddBookDescription(book);
                repository.AddBookDescription(book);
                repository.AddBookDescription(book);
                Assert.Fail();
            }
            catch (ArgumentException ex) {}

            count = repository.GetAllBookDescriptions().Count();
            Assert.AreNotEqual(count, 5);

            Assert.AreEqual(repository.GetAllBookCopies().Count(), 5);
            repository.AddBookCopy(repository.GetBookCopy(0));
            Assert.AreEqual(repository.GetAllBookCopies().Count(), 5);

            Assert.AreEqual(repository.GetAllBookEvents().Count(), 7);
            repository.AddBookEvent(repository.GetBookEvent(0));
            Assert.AreEqual(repository.GetAllBookEvents().Count(), 7);
        }

        [TestMethod]
        public void AddBookCopyConsistencyTest()
        {
            var bookDescription = new BookDescription("The Witcher", "Sapko", "JDPublish");
            var bookCopy = new BookCopy(bookDescription, new DateTime(1999, 13, 13), "3232646894322");
            Assert.AreEqual(repository.GetAllBookDescriptions().Count(), 4);
            repository.AddBookCopy(bookCopy);
            Assert.AreEqual(repository.GetAllBookDescriptions().Count(), 5);
        }
    }
}
