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


            Assert.AreEqual(repository.GetBookCopy(0).Book.Author, new BookCopy(book, new DateTime(2018, 5, 23)).Book.Author);
            

            
        }
    }
}
