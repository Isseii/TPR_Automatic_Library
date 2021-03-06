﻿using System;
using System.Collections.Generic;
using System.Linq;
using Zad4Database;
using Zad4Database.MyCategory;

namespace Zad4Service
{
    public class MyCategoryService : IMyCategoryService
    {
        private IMyCategoryRepository myCategoryRepository;


        public MyCategoryService()
        {
            this.myCategoryRepository = new MyCategoryRepository(new DataBaseTablesDataContext());
        }

        public void AddProductCategory(String name, String date)
        {
            ProductCategory category = new ProductCategory();
            category.Name = name;
            category.ModifiedDate = DateTime.Parse(date);
            category.rowguid = Guid.NewGuid();
            myCategoryRepository.AddProductCategory(new Zad4Database.MyCategory.MyCategory(category));
        }
        public void DeleteProductCategory(int id)
        {

            try
            {
                myCategoryRepository.DeleteProductCategory(id);
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw e;
            }
         
        }

        public List<MyCategory> GetAllProductCategories()
        {
            return myCategoryRepository.GetAllProductCategories().Select(c => new MyCategory(c.ProductCategoryID, c.Name, c.ModifiedDate)).ToList(); 
        }

        public List<MyCategory> GetMyProductCategoryByName(string name)
        {
            return myCategoryRepository.GetMyProductCategoryByName(name).Select(c =>  new MyCategory(c.ProductCategoryID, c.Name, c.ModifiedDate)).ToList();
        }

        public void UpdateProductCategory(string name, int id)
        {
            myCategoryRepository.UpdateProductCategory(name, id);
        }

        public List<MyCategory> GetMyProductCategoryById(int id)
        {
            return myCategoryRepository.GetMyProductCategoryById(id).Select(c => new MyCategory(c.ProductCategoryID, c.Name, c.ModifiedDate)).ToList();
        }
    }
}
