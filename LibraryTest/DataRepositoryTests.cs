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
        [TestMethod]
        public void AddRemoveRepositoryTest()
        {
            AbstractDataRepository repository = new DataRepository();
            Populator populator = new Populator();
            DataPopulator dataPopulator = new DataPopulator(repository, populator);
            dataPopulator.populate();


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

        }
    }
}
