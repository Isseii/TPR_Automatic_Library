using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad4ViewModel
{
    public interface IModelWrapper
    {
        void AddProductCategory(string name, string date);
        void DeleteProductCategory(int id);
        List<MyCategory> GetAllProductCategories();
        List<MyCategory> GetMyProductCategoryById(int id);
        List<MyCategory> GetMyProductCategoryByName(string name);
        void UpdateProductCategory(string name, int id);
    }
}

