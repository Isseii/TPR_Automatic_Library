using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zad3DatabaseLINQ.MyProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad3DatabaseLINQ.MyProduct.Tests
{
    [TestClass()]
    public class MyProductRepositoryTests
    {
        private List<Product> myProducts;
        private MyProductRepository repository;

        [TestInitialize()]
        public void setup()
        {
            DataBaseTablesDataContext dataContext = new DataBaseTablesDataContext();
            myProducts = dataContext.Products.AsEnumerable().ToList();
            repository = new MyProductRepository(new DataBaseTablesDataContext());
        }



        [TestMethod()]
        public void MyProductRepositoryTest()
        {
            Assert.AreEqual(repository.myProducts.Count, myProducts.Select(p => new MyProduct(p)).AsEnumerable().ToList().Count);
            Assert.AreEqual(repository.myProducts[0].ProductID, myProducts.Select(p => new MyProduct(p)).AsEnumerable().ToList()[0].ProductID);
        }

        [TestMethod()]
        public void GetMyProductByNameTest()
        {
            var list = repository.GetMyProductByName("Stem");
            Assert.AreEqual(list.First().Name, "Stem");
            Assert.AreEqual(list.Count, 1);
        }

        [TestMethod()]
        public void GetProductsWithNRecentReviewsTest()
        {
            var list = repository.GetProductsWithNRecentReviews(2);
            Assert.AreEqual(list.First().ProductReviews.Count, 2);
            Assert.AreEqual(list.Count, 1);
        }

        [TestMethod()]
        public void GetNProductsFromCategoryTest()
        {
            var list = repository.GetNProductsFromCategory("Bikes", 4);
            Assert.AreEqual(list.Count, 4);
            Assert.AreEqual(list.First().ProductSubcategory.ProductCategory.Name, "Bikes");
        }
    }
}