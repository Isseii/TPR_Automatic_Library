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
        public void AddEventTest()
        {
            DataContext dataContext = new DataContext();
            AbstractDataRepository repository = new DataRepository();
            Populator populator = new Populator();
            DataPopulator dataPopulator = new DataPopulator(repository,populator);
            
            dataPopulator.populate();

            var book = new BookDescription("Metro 2033", "Dmitry Glukhovsky", "Insignis");

            var Reader = new Reader("Dominik", "Karski");

            Assert.AreEqual(repository.GetBookCopy(0).Book, book);

            Assert.AreEqual(repository.GetReader(0), Reader);

            var reader1 = new Reader("Joe", "Biden");

            var bookDesc = new BookDescription("Metro 2033", "Dmitry Glukhovsky", "Insignis");

            var book1 = new BookCopy(bookDesc, new DateTime(2018, 5, 23), "1234567890123");


            Assert.AreEqual(repository.GetBookEvent(0), new Rent(book1 , reader1, new DateTime(2020, 4, 4)));
        }
    }
}
