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
    public class QueryToolsTests
    {
        [TestMethod()]
        public void GetProductsByNameTest()
        {
            string name = "Blade";
            var tmp = QueryTools.GetProductsByName(name);

            Assert.AreEqual(tmp[0].ProductID, 316);
            Assert.AreEqual(tmp[0].Name, name);
        }

        [TestMethod()]
        public void GetProductsByVendorNameTest()
        {
            string name = "Australia Bike Retailer";
            var tmp = QueryTools.GetProductNamesByVendorName(name);

            Assert.AreEqual(tmp.Count ,16);
            Assert.AreEqual(tmp[0], "Thin-Jam Lock Nut 9");
        }

        [TestMethod()]
        public void GetProductNamesByVendorNameTest()
        {

        }

        [TestMethod()]
        public void GetProductVendorByProductNameTest()
        {
    
        }

        [TestMethod()]
        public void GetProductsWithNRecentReviewsTest()
        {
     
        }

        [TestMethod()]
        public void GetNRecentlyReviewedProductsTest()
        {
      
        }

        [TestMethod()]
        public void GetNProductsFromCategoryTest()
        {
      
        }

        [TestMethod()]
        public void GetTotalStandardCostByCategoryTest()
        {
    
        }
    }
}