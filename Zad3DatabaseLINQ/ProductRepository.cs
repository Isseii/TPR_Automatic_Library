using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad3DatabaseLINQ
{
    class ProductRepository
    {
        public static List<MyProduct> myProducts = new List<MyProduct>();

        public List<MyProduct> GetMyProductByName(string name)
        {
            var output = from product in myProducts
                         where product.Name.Contains(name)
                         select product;

            return output.ToList();
        }

        public List<MyProduct> GetProductsWithNRecentReviews(int howManyReviews)
        {
            var output = from product in MyProductRepository.myProducts
                         where product.ProductReviews.Count.Equals(howManyReviews)
                         select product;

            return output.ToList();
        }
    }
}
