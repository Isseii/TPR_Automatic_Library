using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad3DatabaseLINQ
{
    public static class ExtensionMethods
    {
        public static List<Product> GetProductsWithoutCategoryQuery(this List<Product> products)
        {
            List<Product> categoryLess = (from product in products
                                          where product.ProductSubcategory is null
                                          select product).ToList<Product>();

            return categoryLess;
        }

        public static List<Product> GetProductsWithoutCategoryExtension(this List<Product> products)
        {
            return products.Where(x => x.ProductSubcategory == null).ToList();
        }

        public static List<Product> GetNPageWithXResultsExtension(this List<Product> products, int page, int results)
        {
            return products.Skip((page - 1) * results).Take(results).ToList();
        }
        public static List<Product> GetNPageWithXResultsQuery(this List<Product> products, int page, int results)
        {
            return (from product in products.Skip((page - 1) * results).Take(results) select product).ToList();
        }
         

        public static string GetProductAndVendorNamePairQuery(this List<Product> products)
        {
            using (DataBaseTablesDataContext dataContext = new DataBaseTablesDataContext())
            {
                Table<ProductVendor> productsVendors = dataContext.GetTable<ProductVendor>();
                List<ProductVendor> vendors = (from productVendor in productsVendors select productVendor).ToList();

                string pairs = "";

                var result = (from product in products
                              from vendor in vendors
                              where product.ProductID.Equals(vendor.ProductID)
                              select new { productName = product.Name, vendorName = vendor.Vendor.Name }).ToList();
                 
                foreach(var x in result)
                {
                    pairs += x.productName + " - " + x.vendorName + "\n";
                }
                return pairs;

            }
        }

        public static string GetProductAndVendorNamePairExtension(this List<Product> products)
        {
            using (DataBaseTablesDataContext dataContext = new DataBaseTablesDataContext())
            {
                Table<ProductVendor> productsVendors = dataContext.GetTable<ProductVendor>();
                List<ProductVendor> vendors = (from productVendor in productsVendors select productVendor).ToList();

                string pairs = "";

                var result = products.Join(vendors, product => product.ProductID, vendor => vendor.ProductID,
                                           (product, vendor) => new { productName = product.Name, vendorName = vendor.Vendor.Name }).ToList();

                foreach (var x in result)
                {
                    pairs += x.productName + " - " + x.vendorName + "\n";
                }
                return pairs;

            }
        }
    }
}
