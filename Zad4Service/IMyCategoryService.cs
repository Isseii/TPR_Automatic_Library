using System.Collections.Generic;
using Zad4Database.MyCategory;

namespace Zad4Service
{
    public interface IMyCategoryService
    {
        void AddProductCategory(string name, string date);
        void DeleteProductCategory(int id);
        List<MyCategory> GetAllProductCategories();
        List<MyCategory> GetMyProductCategoryById(int id);
        List<MyCategory> GetMyProductCategoryByName(string name);
        void UpdateProductCategory(string name, int id);
    }
}