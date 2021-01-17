using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zad4ViewModel;

namespace Zad4MVVMTest
{
    [TestClass]
    public class ViewModelTest
    {

        private ViewModel viewModel;

        [TestInitialize()]
        public void SetUp()
        {
            viewModel = new ViewModel(new TestingModel());
            viewModel.MessageBox = new WindowManager();
            viewModel.InfoWindow = new WindowManager();
            viewModel.disableAsync = true;
        }

        [TestMethod]
        public void AllCountTest()
        {
            int x = viewModel.ProductCategories.Count;
            Assert.AreEqual(x, 5);
        }

        [TestMethod]
        public void AddCategoryTest()
        {
            int counter = viewModel.ProductCategories.Count;

            viewModel.Name = "AGD";
            viewModel.AddCategory.Execute(null);
            viewModel.GetAllData.Execute(null);

            Assert.AreEqual(counter + 1, viewModel.ProductCategories.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Name field incorrect value")]
        public void AddEmptyCategoryTest()
        {
            viewModel.Name = "";
            viewModel.AddCategory.Execute(null);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Name field incorrect value")]
        public void AddNullCategoryTest()
        {
            viewModel.Name = null;
            viewModel.AddCategory.Execute(null);
        }

        [TestMethod]
        public void RemoveCategoryTest()
        {
            int counter = viewModel.ProductCategories.Count;

            viewModel.ProductCategory = viewModel.ProductCategories[0];
            viewModel.RemoveCategory.Execute(null);
            viewModel.GetAllData.Execute(null);

            Assert.AreEqual(counter - 1, viewModel.ProductCategories.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Id field incorrect value")]
        public void RemoveIdZeroTest()
        {
            viewModel.ProductCategory = new MyCategory(0, "example", DateTime.Now);
            viewModel.RemoveCategory.Execute(null);
        }

        [TestMethod]
        public void UpdateCategoryTest()
        {
            viewModel.ProductCategory = viewModel.ProductCategories[0];
            Assert.AreEqual(viewModel.ProductCategory.Name, "Bicycle");

            viewModel.Name = "Rower";
            viewModel.UpdateCategory.Execute(null);
            viewModel.GetAllData.Execute(null);
            Assert.AreEqual(viewModel.ProductCategories[0].Name, "Rower");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Name field incorrect value")]
        public void UpdateEmptyTest()
        {
            viewModel.ProductCategory = viewModel.ProductCategories[0];
            Assert.AreEqual(viewModel.ProductCategory.Name, "Bicycle");

            viewModel.Name = "";
            viewModel.UpdateCategory.Execute(null);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Name field incorrect value")]
        public void UpdateNullTest()
        {
            viewModel.ProductCategory = viewModel.ProductCategories[0];
            Assert.AreEqual(viewModel.ProductCategory.Name, "Bicycle");

            viewModel.Name = null;
            viewModel.UpdateCategory.Execute(null);
        }

        [TestMethod]
        public void CategoryInfoTest()
        {
            viewModel.ProductCategory = viewModel.ProductCategories[1];
            Assert.AreEqual(viewModel.ProductCategory.Name, "Book");
            Assert.AreEqual(viewModel.ProductCategory.Id, 2);

            viewModel.Info.Execute(null);
            MyCategory tmp = viewModel.ProductCategoriesInfo[0];
            Assert.AreEqual(tmp.Name, viewModel.ProductCategory.Name);
            Assert.AreEqual(tmp.Id, viewModel.ProductCategory.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Select any object!")]
        public void CategoryInfoNullTest()
        {
            viewModel.ProductCategory = null;
            viewModel.Info.Execute(null);
        }
    }
}
