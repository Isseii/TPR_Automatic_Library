using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zad3DatabaseLINQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad3DatabaseLINQ.Tests
{
    [TestClass()]
    public class ExtensionMethodsTests
    {
        
        private List<Product> myProducts;
        [TestInitialize()]
        public void setup()
        {
            DataBaseTablesDataContext dataContext = new DataBaseTablesDataContext();
            myProducts = dataContext.Products.AsEnumerable().ToList();
        }
    

        [TestMethod()]
        public void GetProductsWithoutCategoryQueryTest()
        {
           var tmp =  myProducts.GetProductsWithoutCategoryQuery();
            Assert.AreEqual(tmp.Count, 209);
        }

        [TestMethod()]
        public void GetProductsWithoutCategoryExtensionTest()
        {
            var tmp = myProducts.GetProductsWithoutCategoryExtension();
            Assert.AreEqual(tmp.Count, 209);
        }

        [TestMethod()]
        public void GetNPageWithXResultsExtensionTest()
        {
            var tmp = myProducts.GetNPageWithXResultsExtension(5, 8);

            Assert.AreEqual(tmp.Count, 8);
            Assert.AreEqual(tmp[2].Name, "LL Grip Tape");

        }

        [TestMethod()]
        public void GetNPageWithXResultsQueryTest()
        {
            var tmp = myProducts.GetNPageWithXResultsQuery(5, 8);

            Assert.AreEqual(tmp.Count, 8);
            Assert.AreEqual(tmp[2].Name, "LL Grip Tape");
        }

        [TestMethod()]
        public void GetProductAndVendorNamePairQueryTest()
        {
            var tmp = myProducts.GetProductAndVendorNamePairQuery();

            Assert.AreEqual(tmp.Length, 17518);
            Assert.AreEqual(tmp.Count(c => c.Equals('\n')), 460);
            Assert.IsTrue(tmp.Contains("HL Crankarm - West Junction Cycles"));      
        }

        [TestMethod()]
        public void GetProductAndVendorNamePairExtensionTest()
        {
            var tmp = myProducts.GetProductAndVendorNamePairExtension();

            Assert.AreEqual(tmp.Length, 17518);
            Assert.AreEqual(tmp.Count(c => c.Equals('\n')), 460);
            Assert.IsTrue(tmp.Contains("HL Crankarm - West Junction Cycles"));
        }
    }
}