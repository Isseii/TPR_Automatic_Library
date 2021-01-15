using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad4Database.MyCategory
{
    public class MyCategoryRepository : IMyCategoryRepository
    {
        public List<MyCategory> myCategories;

        public MyCategoryRepository(DataBaseTablesDataContext dataContext)
        {
            myCategories = dataContext.ProductCategory.AsEnumerable().Select(category => new MyCategory(category)).ToList();
        }

        public List<MyCategory> GetMyProductCategoryByName(string name)
        {
            var output = from category in myCategories
                         where category.Name.Contains(name)
                         select category;

            return output.ToList();
        }


        public List<MyCategory> GetAllProductCategories()
        {
            var output = from category in myCategories select category;

            return output.ToList();
        }


        public void AddProductCategory(ProductCategory productCategory)
        {
            using (DataBaseTablesDataContext dataContext = new DataBaseTablesDataContext())
            {
                dataContext.ProductCategory.InsertOnSubmit(productCategory);
                dataContext.SubmitChanges();
            }
        }

        public void UpdateProductCategory(string name, int id)
        {
            using (DataBaseTablesDataContext dataContext = new DataBaseTablesDataContext())
            {

                ProductCategory output = dataContext.ProductCategory.SingleOrDefault(productCategory => productCategory.ProductCategoryID == id);

                output.Name = name;
                dataContext.SubmitChanges();
            }
        }

        public void DeleteProductCategory(int id)
        {
            using (DataBaseTablesDataContext dataContext = new DataBaseTablesDataContext())
            {

                ProductCategory output = dataContext.ProductCategory.SingleOrDefault(productCategory => productCategory.ProductCategoryID == id);

                if (output != null)
                {
                    dataContext.ProductCategory.DeleteOnSubmit(output);
                    dataContext.SubmitChanges();
                }
            }
        }

    }
}
