using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Automatic_Library.Data;
using Automatic_Library.Data.DataPopulator;
using Automatic_Library.Data.ObjectModel;
using System.Linq;
using Automatic_Library.Data.ObjectModel.BookEvent;
using LibraryTest.DataFiller;

namespace LibraryTest.DataRepositoryTests
{
    [TestClass]
    public class DataRepositoryTests
    {
        AbstractDataRepository repository;

        [TestInitialize()]
        public void SetUp()
        {
            repository = new DataRepository();
            ConstPopulator populator = new ConstPopulator();
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
            Assert.AreEqual(count, 5);
         
            repository.AddBookDescription(book);
            repository.AddBookDescription(book);
            repository.AddBookDescription(book);
            Assert.AreEqual(count, 5);

            count = repository.GetAllBookDescriptions().Count();
            Assert.AreNotEqual(count, 6);

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
            var bookCopy = new BookCopy(bookDescription, new DateTime(1999, 12, 13), "3232646894322");
            var counter = repository.GetAllBookDescriptions().Count();
            Assert.AreEqual(repository.GetAllBookDescriptions().Count(), counter);
            repository.AddBookCopy(bookCopy);
            Assert.AreEqual(repository.GetAllBookDescriptions().Count(), counter + 1);
        }

        [TestMethod]
        public void AddBookDescriptionConsistencyTest()
        {
            var bookDescription = repository.GetBookDescription("Harry Potter");
            Assert.AreEqual(repository.GetAllBookDescriptions().Count(), 5);
            repository.AddBookDescription(bookDescription);
            Assert.AreEqual(repository.GetAllBookDescriptions().Count(), 5);
        }

        [TestMethod]
        public void AddReaderConsistencyTest()
        {
            var reader = repository.GetReader(0);
            Assert.AreEqual(repository.GetAllReaders().Count(), 4);
            repository.AddReader(reader);
            Assert.AreEqual(repository.GetAllReaders().Count(), 4);
        }

        [TestMethod]
        public void AddBookEventAllowedOperationsConsistencyTest()
        {
            var bookEvent = repository.GetBookEvent(0);
            Assert.AreEqual(repository.GetAllBookEvents().Count(), 7);
            repository.AddBookEvent(bookEvent);
            Assert.AreEqual(repository.GetAllBookEvents().Count(), 7);

            var rentWithoutBookCopy = new Rent(
                new BookCopy(repository.GetBookDescription("Harry Potter"),
                new DateTime(2015, 5, 23), "3237567890123"),
                repository.GetReader(0),
                DateTime.Now);
            Assert.AreEqual(repository.GetAllBookEvents().Count(), 7);
            repository.AddBookEvent(rentWithoutBookCopy);
            Assert.AreEqual(repository.GetAllBookEvents().Count(), 7);

            var returnWithoutBookCopy = new Return(
              new BookCopy(repository.GetBookDescription("Harry Potter"),
              new DateTime(2015, 5, 23), "3237356567123"),
              repository.GetReader(0),
              DateTime.Now);

            Assert.AreEqual(repository.GetAllBookEvents().Count(), 7);
            repository.AddBookEvent(returnWithoutBookCopy);
            Assert.AreEqual(repository.GetAllBookEvents().Count(), 8);

        }

        [TestMethod]
        public void AddBookEventAvailabilityConsistencyTest()
        {
            var bookCopy = repository.GetBookCopy(0);
            bookCopy.State = BookCopy.Availability.Unavailable;
            Assert.AreEqual(repository.GetAllBookEvents().Count(), 7);
            Rent rent = new Rent(bookCopy, repository.GetReader(0), DateTime.Now);
            repository.AddBookEvent(rent);
            Assert.AreEqual(repository.GetAllBookEvents().Count(), 7);

            var bookCopy1 = repository.GetBookCopy(0);
            bookCopy1.State = BookCopy.Availability.Available;
            Assert.AreEqual(repository.GetAllBookEvents().Count(), 7);
            Return bookReturn = new Return(bookCopy1, repository.GetReader(0), DateTime.Now);
            repository.AddBookEvent(bookReturn);
            Assert.AreEqual(repository.GetAllBookEvents().Count(), 7);
        }

        [TestMethod]
        public void DeleteBookCopyConsistencyTest()
        {
            Assert.AreEqual(repository.GetAllBookCopies().Count(), 5);
            repository.DeleteBookCopy(repository.GetBookCopy(0));
            Assert.AreEqual(repository.GetAllBookCopies().Count(), 5);

            var book = new BookCopy(repository.GetBookDescription("Metro 2033"), new DateTime(1989, 2, 5), "7658484876543");
            repository.AddBookCopy(book);
            Assert.AreEqual(repository.GetAllBookCopies().Count(), 6);
            repository.DeleteBookCopy(book);
            Assert.AreEqual(repository.GetAllBookCopies().Count(), 5);
        }

        [TestMethod]
        public void DeleteBookDescriptionConsistencyTest()
        {
            Assert.AreEqual(repository.GetAllBookDescriptions().Count(), 5);
            repository.DeleteBookDescription(repository.GetBookCopy(0).Book);
            Assert.AreEqual(repository.GetAllBookDescriptions().Count(), 5);

            var book = new BookDescription("Książka", "Bezimienny", "Null");
            repository.AddBookDescription(book);
            Assert.AreEqual(repository.GetAllBookDescriptions().Count(), 6);
            repository.DeleteBookDescription(book);
            Assert.AreEqual(repository.GetAllBookDescriptions().Count(), 5);
        }

        [TestMethod]
        public void DeleteReaderConsistencyTest()
        {
            Assert.AreEqual(repository.GetAllReaders().Count(), 4);
            repository.DeleteReader(repository.GetReader(3));
            Assert.AreEqual(repository.GetAllReaders().Count(), 4);
            Reader tmp = new Reader("Krzysztof", "Gonciarz");
            repository.AddReader(tmp);
            Assert.AreEqual(repository.GetAllReaders().Count(), 5);
            repository.DeleteReader(tmp);
            Assert.AreEqual(repository.GetAllReaders().Count(), 4);
        }

  
        [TestMethod]
        public void DeleteBookEventConsistencyTest()
        {
            Assert.AreEqual(repository.GetAllBookEvents().Count(), 7);
            repository.DeleteBookEvent(repository.GetBookEvent(0));
            Assert.AreEqual(repository.GetAllBookEvents().Count(), 6);
        }

    }
}
