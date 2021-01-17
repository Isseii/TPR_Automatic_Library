using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zad4ViewModel;

namespace Zad4MVVMTest
{
    [TestClass]
    public class ModelTest
    {
        private ViewModel viewModel;

        [TestInitialize()]
        public void SetUp()
        {
            viewModel = new ViewModel(new TestingModel());
        }

        [TestMethod]
        public void GetByNameTest()
        {

            var x = viewModel.Model.GetMyProductCategoryByName("Bicycle")[0];
            Assert.AreEqual(x.Name, "Bicycle");
        }

        [TestMethod]
        public void AddProductTest() 
        {
            int counter = viewModel.Model.GetAllProductCategories().Count;
            viewModel.Model.AddProductCategory("Computers", DateTime.Now.ToString());
            Assert.AreEqual(counter + 1, viewModel.Model.GetAllProductCategories().Count);
        }

        [TestMethod]
        public void DeleteProductTest()
        {
            int counter = viewModel.Model.GetAllProductCategories().Count;
            viewModel.Model.DeleteProductCategory(1);
            Assert.AreEqual(counter - 1, viewModel.Model.GetAllProductCategories().Count);
        }

        [TestMethod]
        public void GetByIdTest()
        {
            MyCategory mcat = viewModel.Model.GetMyProductCategoryById(1)[0];
            Assert.AreEqual(1, mcat.Id);
        }

        [TestMethod]
        public void GetAllTest()
        { 
            Assert.AreEqual(viewModel.Model.GetAllProductCategories().Count, 5);
        }
    }
}
