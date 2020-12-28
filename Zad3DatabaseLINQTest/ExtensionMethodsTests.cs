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
         
        }

        [TestMethod()]
        public void GetNPageWithXResultsQueryTest()
        {
    
        }

        [TestMethod()]
        public void GetProductAndVendorNamePairQueryTest()
        {
         
        }

        [TestMethod()]
        public void GetProductAndVendorNamePairExtensionTest()
        {
       
        }
    }
}