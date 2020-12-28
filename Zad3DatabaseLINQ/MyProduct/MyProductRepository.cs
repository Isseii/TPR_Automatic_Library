using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad3DatabaseLINQ.MyProduct
{
    class ProductRepository
    {
        public static List<MyProduct> myProducts;

        public ProductRepository(DataBaseTablesDataContext dataContext)
        {
            myProducts = dataContext.Products.AsEnumerable().Select(product => new MyProduct(product)).ToList();
        }

        public List<MyProduct> GetMyProductByName(string name)
        {
            var output = from product in myProducts
                         where product.Name.Contains(name)
                         select product;

            return output.ToList();
        }

        public List<MyProduct> GetProductsWithNRecentReviews(int howManyReviews)
        {
            var output = from product in myProducts
                         where product.ProductReviews.Count.Equals(howManyReviews)
                         select product;

            return output.ToList();
        }

        public List<MyProduct> GetNProductsFromCategory(string categoryName, int n)
        {
            List<MyProduct> result = (from product in myProducts
                                    orderby product.ProductSubcategory.Name.Equals(categoryName)
                                    select product).Take(n).ToList();
            return result;
        }
    }
}
