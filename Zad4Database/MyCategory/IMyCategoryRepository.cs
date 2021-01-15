using System.Collections.Generic;

namespace Zad4Database.MyCategory
{
    public interface IMyCategoryRepository
    {
        void AddProductCategory(ProductCategory productCategory);
        void DeleteProductCategory(int id);
        List<MyCategory> GetAllProductCategories();
        List<MyCategory> GetMyProductCategoryByName(string name);
        void UpdateProductCategory(string name, int id);
    }
}