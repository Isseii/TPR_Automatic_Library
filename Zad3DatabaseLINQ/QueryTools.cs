using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad3DatabaseLINQ
{
    public class QueryTools
    {


        public static List<Product> GetProductsByName(string namePart)
        {
            using (DataBaseTablesDataContext dataContext = new DataBaseTablesDataContext())
            {
                Table<Product> products = dataContext.GetTable<Product>();
                List<Product> answer = (from product in products
                                        where product.Name.Contains(namePart)
                                        select product).ToList();
                return answer;
            }
        }

        public static List<Product> GetProductsByVendorName(string vendorName)
        {
            using (DataBaseTablesDataContext dataContext = new DataBaseTablesDataContext())
            {
                Table<ProductVendor> productsVendors = dataContext.GetTable<ProductVendor>();
                List<Product> answer = (from productVendor in productsVendors
                                        where productVendor.Vendor.Name.Equals(vendorName)
                                        select productVendor.Product).ToList();
                return answer;
            }
        }

        public static List<string> GetProductNamesByVendorName(string vendorName)
        {
            using (DataBaseTablesDataContext dataContext = new DataBaseTablesDataContext())
            {
                Table<ProductVendor> productVendors = dataContext.GetTable<ProductVendor>();
                List<string> productsName = (from productVendor in productVendors
                                             where productVendor.Vendor.Name.Equals(vendorName)
                                             select productVendor.Product.Name).ToList();
                return productsName;
            }
        }

        public static string GetProductVendorByProductName(string productName)
        {
            using (DataBaseTablesDataContext dataContext = new DataBaseTablesDataContext())
            {
                Table<ProductVendor> productVendors = dataContext.GetTable<ProductVendor>();
                string vendors = (from productVendor in productVendors
                                  where productVendor.Product.Name.Equals(productName)
                                  select productVendor.Vendor.Name).First();
                return vendors;
            }
        }

        public static List<Product> GetProductsWithNRecentReviews(int howManyReviews)
        {
            using (DataBaseTablesDataContext dataContext = new DataBaseTablesDataContext())
            {
                Table<Product> productsTable = dataContext.GetTable<Product>();
                List<Product> products = (from product in productsTable
                                          where product.ProductReviews.Count == howManyReviews
                                          select product).ToList();
                return products;
            }
        }

        public static List<Product> GetNRecentlyReviewedProducts(int howManyProducts)
        {
            using (DataBaseTablesDataContext dataContext = new DataBaseTablesDataContext())
            {
                Table<ProductReview> productReviews = dataContext.GetTable<ProductReview>();
                List<Product> products = (from productReview in productReviews
                                          orderby productReview.ReviewDate descending
                                          select productReview.Product
                                          ).Take(howManyProducts).ToList();
                return products;
            }
        }

        public static List<Product> GetNProductsFromCategory(string categoryName, int n)
        {
            using (DataBaseTablesDataContext dataContext = new DataBaseTablesDataContext())
            {
                Table<Product> productsTable = dataContext.GetTable<Product>();
                List<Product> products = (from product in productsTable
                                          where product.ProductSubcategory.ProductCategory.Name.Equals(categoryName)
                                          select product).Take(n).ToList();
                return products;
            }
        }

        public static int GetTotalStandardCostByCategory(ProductCategory category)
        {
            using (DataBaseTablesDataContext dataContext = new DataBaseTablesDataContext())
            {
                Table<Product> productsTable = dataContext.GetTable<Product>();
                decimal sum = (from product in productsTable
                               where product.ProductSubcategory.ProductCategory.Name.Equals(category.Name)
                               select product.StandardCost).ToList().Sum();
                return (int)sum;
            }
        }
    }
}

