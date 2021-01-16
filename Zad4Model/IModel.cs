using System.Collections.Generic;

namespace Zad4Model
{
    public interface IModel
    {
        void AddProductCategory( string name, string date);
        void DeleteProductCategory(int id);
        List<MyCategory> GetAllProductCategories();
        List<MyCategory> GetMyProductCategoryById(int id);
        List<MyCategory> GetMyProductCategoryByName(string name);
        void UpdateProductCategory(string name, int id);
    }
}