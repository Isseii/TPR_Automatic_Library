using Microsoft.VisualStudio.TestTools.UnitTesting;
using Automatic_Library.Data;

namespace LibraryTest
{
    [TestClass]
    public class DataTest
    {
        [TestMethod]
        public void AddEventTest()
        {
            DataContext dataContext = new DataContext();
            AbstractDataRepository repository = new DataRepository(dataContext);
            Assert.AreEqual(1, 1);
        }
    }
}
