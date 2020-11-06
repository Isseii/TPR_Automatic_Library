using Microsoft.VisualStudio.TestTools.UnitTesting;
using Automatic_Library.Data;
using Automatic_Library.Data.DataPopulator;
using Automatic_Library.Data.ObjectModel;
using Automatic_Library.Data.ObjectModel.BookEvent;
using System;


namespace LibraryTest
{
    [TestClass]
    public class DataTest
    {
        [TestMethod]
        public void DataPopulatorTest()
        {
            DataContext dataContext = new DataContext();
            AbstractDataRepository repository = new DataRepository();
            Populator populator = new Populator();
            DataPopulator dataPopulator = new DataPopulator(repository,populator);
            dataPopulator.populate();

            Assert.AreEqual(repository.GetReader(0), new Reader("Dominik", "Karski"));
            Assert.AreEqual(repository.GetReader(1), new Reader("Sebastian", "Kujawski"));
            Assert.AreEqual(repository.GetReader(2), new Reader("Joe", "Biden"));
            Assert.AreEqual(repository.GetReader(3), new Reader("Donald", "Trump"));

            
            var book = new BookDescription("Metro 2033", "Dmitry Glukhovsky", "Insignis");
            Assert.AreEqual(repository.GetBookDescription(book.Title), book);
            var book1 = new BookDescription("Diuna", "Frank Herbert", "Rebis");
            Assert.AreEqual(repository.GetBookDescription(book1.Title), book1);
            var book2 = new BookDescription("Harry Potter", "J.K.Rowling", "Media Rodzina");
            Assert.AreEqual(repository.GetBookDescription(book2.Title), book2);
            var book3 = new BookDescription("Pan Lodowego Ogrodu (tom 1)", "Jarosław Grzędowicz", "Fabryka Słów");
            Assert.AreEqual(repository.GetBookDescription(book3.Title), book3);

            Assert.AreEqual(repository.GetBookCopy(0), new BookCopy(book, new DateTime(2018, 5, 23), "1234567890123"));
            Assert.AreEqual(repository.GetBookCopy(1), new BookCopy(book, new DateTime(2005, 2, 22), "2234567890123"));
            Assert.AreEqual(repository.GetBookCopy(2), new BookCopy(book1, new DateTime(2012, 2, 1), "3234567890123"));
            Assert.AreEqual(repository.GetBookCopy(3), new BookCopy(book2, new DateTime(1999, 1, 13), "4234567890123"));
            Assert.AreEqual(repository.GetBookCopy(4), new BookCopy(book3, new DateTime(2003, 5, 27), "5234567890123"));

            Assert.AreEqual(repository.GetBookEvent(0),
                new Rent(new BookCopy(book, new DateTime(2015, 5, 23), "1234567890123"),
                new Reader("Joe", "Biden"), new DateTime(2017, 4, 4)));
            Assert.AreEqual(repository.GetBookEvent(1),
                new Rent(new BookCopy(book3, new DateTime(2003, 5, 27), "5234567890123"),
                new Reader("Dominik", "Karski"), new DateTime(2017, 11, 6)));
            Assert.AreEqual(repository.GetBookEvent(2),
                new Rent(new BookCopy(book1, new DateTime(2012, 2, 1), "3234567890123"),
                new Reader("Sebastian", "Kujawski"), new DateTime(2018, 3, 3)));
            Assert.AreEqual(repository.GetBookEvent(3),
                new Rent(new BookCopy(book, new DateTime(2005, 2, 22), "2234567890123"),
                new Reader("Donald", "Trump"), new DateTime(2018, 4, 4)));
            Assert.AreEqual(repository.GetBookEvent(4),
                new Rent(new BookCopy(book2, new DateTime(1999, 1, 13), "4234567890123"),
                new Reader("Joe", "Biden"), new DateTime(2020, 5, 5)));
            Assert.AreEqual(repository.GetBookEvent(5),
                new Return(new BookCopy(book, new DateTime(2015, 5, 23), "1234567890123"),
                new Reader("Joe", "Biden"), new DateTime(2020, 10, 10)));
            Assert.AreEqual(repository.GetBookEvent(6),
                new Return(new BookCopy(book, new DateTime(2005, 2, 22), "2234567890123"),
                new Reader("Donald", "Trump"), new DateTime(2020, 11, 6)));
        }
    }
}
