﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            string name = "Victory Bikes";
            var tmp = QueryTools.GetProductsByVendorName(name);

            Assert.AreEqual(tmp.Count, 4);
            Assert.AreEqual(tmp[0].Name, "Road Tire Tube");

        }

        [TestMethod()]
        public void GetProductNamesByVendorNameTest()
        {
            string name = "Australia Bike Retailer";
            var tmp = QueryTools.GetProductNamesByVendorName(name);

            Assert.AreEqual(tmp.Count, 16);
            Assert.AreEqual(tmp[0], "Thin-Jam Lock Nut 9");
        }

        [TestMethod()]
        public void GetProductVendorByProductNameTest()
        {
            string name = "LL Shell";
            var tmp = QueryTools.GetProductVendorByProductName(name);

            Assert.AreEqual(tmp, "Federal Sport");


        }

        [TestMethod()]
        public void GetProductsWithNRecentReviewsTest()
        {
            var tmp = QueryTools.GetProductsWithNRecentReviews(2);

            Assert.AreEqual(tmp.Count, 1);
            Assert.AreEqual(tmp[0].ProductID, 937);
        }

        [TestMethod()]
        public void GetNRecentlyReviewedProductsTest()
        {
            var tmp = QueryTools.GetNRecentlyReviewedProducts(5);

            Assert.AreEqual(tmp.Count, 4);
            Assert.AreEqual(tmp[0].ProductID, 937);
        }

        [TestMethod()]
        public void GetNProductsFromCategoryTest()
        {
            var tmp = QueryTools.GetNProductsFromCategory("Clothing", 3);

            Assert.AreEqual(tmp.Count, 3);
            Assert.AreEqual(tmp[0].Name, "Men's Bib-Shorts, S");
        }

        [TestMethod()]
        public void GetTotalStandardCostByCategoryTest()
        {
            ProductCategory category = new ProductCategory();
            category.Name = "clothing";

            var tmp = QueryTools.GetTotalStandardCostByCategory(category);

            Assert.AreEqual(tmp, 868);

        }
    }
}