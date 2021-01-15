using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad3DatabaseLINQ.MyProduct
{
    public class MyProductRepository
    {
        public List<MyProduct> myProducts;

        private ProductionDataContext db = new ProductionDataContext();

        public MyProductRepository(DataBaseTablesDataContext dataContext)
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
                                      where product.ProductSubcategory != null && product.ProductSubcategory.ProductCategory.Name.Equals(categoryName)
                                      orderby product.ProductSubcategory.Name
                                      select product).Take(n).ToList();
            return result;
        }
    }
}
