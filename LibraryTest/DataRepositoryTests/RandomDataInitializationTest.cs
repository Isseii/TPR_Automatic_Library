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
        [TestMethod]
        public void DataPopulatorTest()
        {
            AbstractDataRepository repository = new DataRepository();
            RandomPopulator populator = new RandomPopulator();
            DataPopulator dataPopulator = new DataPopulator(repository, populator);
            dataPopulator.populate();

            Assert.AreEqual(repository.GetAllReaders().Count(),6);
            Assert.AreEqual(repository.GetAllBookDescriptions().Count(), 6);
            Assert.AreEqual(repository.GetAllBookCopies().Count(), 10);
        }
    }
}
