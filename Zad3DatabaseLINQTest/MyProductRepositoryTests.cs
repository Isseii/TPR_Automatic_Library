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
        [TestInitialize()]
        public void setup()
        {
            DataBaseTablesDataContext dataContext = new DataBaseTablesDataContext();
            myProducts = dataContext.Products.AsEnumerable().ToList();
        }



        [TestMethod()]
        public void MyProductRepositoryTest()
        {
            MyProductRepository test = new MyProductRepository(new DataBaseTablesDataContext());
            Assert.AreEqual(test.myProducts.Count, myProducts.Select(p => new MyProduct(p)).AsEnumerable().ToList().Count);
            Assert.AreEqual(test.myProducts[0].ProductID , myProducts.Select(p => new MyProduct(p)).AsEnumerable().ToList()[0].ProductID);
        }

        [TestMethod()]
        public void GetMyProductByNameTest()
        {
            
        }

        [TestMethod()]
        public void GetProductsWithNRecentReviewsTest()
        {
           
        }

        [TestMethod()]
        public void GetNProductsFromCategoryTest()
        {
           
        }
    }
}