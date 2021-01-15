using System;
using System.Collections.Generic;
using Zad4Database;
using Zad4Database.MyCategory;

namespace Zad4Service
{
    public class MyCategoryService : IMyCategoryService
    {
        private IMyCategoryRepository myCategoryRepository;

        public MyCategoryService(IMyCategoryRepository myCategoryRepository)
        {
            this.myCategoryRepository = myCategoryRepository;
        }

        public void AddProductCategory(String name, String date)
        {
            ProductCategory category = new ProductCategory();
            category.Name = name;
            category.ModifiedDate = DateTime.Parse(date);
            myCategoryRepository.AddProductCategory(new MyCategory(category));
        }
        public void DeleteProductCategory(int id)
        {
            myCategoryRepository.DeleteProductCategory(id);
        }

        public List<MyCategory> GetAllProductCategories()
        {
            return myCategoryRepository.GetAllProductCategories();
        }

        public List<MyCategory> GetMyProductCategoryByName(string name)
        {
            return myCategoryRepository.GetMyProductCategoryByName(name);
        }

        public void UpdateProductCategory(string name, int id)
        {
            myCategoryRepository.UpdateProductCategory(name, id);
        }

        public List<MyCategory> GetMyProductCategoryById(int id)
        {
            return myCategoryRepository.GetMyProductCategoryById(id);
        }
    }
}
