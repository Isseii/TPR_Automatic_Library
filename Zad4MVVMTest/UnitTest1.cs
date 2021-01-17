using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zad4ViewModel;

namespace Zad4MVVMTest
{
    [TestClass]
    public class UnitTest1
    {
        private ViewModel viewModel;

        [TestInitialize()]
        public void SetUp()
        {
            viewModel = new ViewModel(new TestingModel());

        }



        [TestMethod]
        public void GetAllCountTest()
        {

            int x = viewModel.ProductCategories.Count;
            Assert.AreEqual(x, 5);
        }


        [TestMethod]
        public void GetByNameTest()
        {

            var x = viewModel.Model.GetMyProductCategoryByName("Bicycle")[0];
            Assert.AreEqual(x.Name, "Bicycle");

        }



    }
}
