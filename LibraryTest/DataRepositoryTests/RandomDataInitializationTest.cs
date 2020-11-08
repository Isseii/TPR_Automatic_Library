using Automatic_Library.Data;
using Automatic_Library.Data.DataPopulator;
using LibraryTest.DataFiller;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryTest.DataRepositoryTests
{

    [TestClass]
    public class RandomDataInitializationTest
    {
        private AbstractDataRepository repository;

        [TestInitialize()]
        public void SetUp()
        {
            repository = new DataRepository();
            RandomPopulator populator = new RandomPopulator();
            DataPopulator dataPopulator = new DataPopulator(repository, populator);
            dataPopulator.populate();
        }

        [TestMethod]
        public void RandomDataPopulatorTest()
        {
            Assert.AreEqual(repository.GetAllReaders().Count(), 6);
            Assert.AreEqual(repository.GetAllBookDescriptions().Count(), 6);
            Assert.AreEqual(repository.GetAllBookCopies().Count(), 10);
            Assert.AreEqual(repository.GetAllBookEvents().Count(), 6);

        }

        [TestMethod]
        public void RandomDataTest()
        {
            RandomDataHolder dataHolder = new RandomDataHolder();
            CollectionAssert.AreNotEquivalent(repository.GetAllBookCopies().ToList(), dataHolder.BookCopies);

        }
    }
}
