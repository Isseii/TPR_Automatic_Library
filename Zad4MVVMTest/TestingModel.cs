using System;
using System.Collections.Generic;
using Zad4ViewModel;

namespace Zad4MVVMTest
{
    public  class TestingModel : IModelWrapper
    {
        List<MyCategory> service = new List<MyCategory>();
        
        

        public TestingModel()
        {
            service.Add(new MyCategory(1, "Bicycle", DateTime.Now));
            service.Add(new MyCategory(2, "Book", DateTime.Now ));
            service.Add(new MyCategory(3, "Glove", DateTime.Now));
            service.Add(new MyCategory(4, "Hat", DateTime.Now));
            service.Add(new MyCategory(5, "Jacket", DateTime.Now));
        }

        public void AddProductCategory(string name, string date)
        {
            service.Add(new MyCategory(service.Count + 1, name, DateTime.Parse(date)));
        }
        public void DeleteProductCategory(int id)
        {
            service.RemoveAll(cat => cat.Id == id);
        }
        public List<MyCategory> GetAllProductCategories()
        {
            return service;
        }

        public List<MyCategory> GetMyProductCategoryById(int id)
        {
            return service.FindAll(x => x.Id == id);
        }
        public List<MyCategory> GetMyProductCategoryByName(string name)
        {
            return service.FindAll(x => x.Name == name);
        }
        public void UpdateProductCategory(string name, int id)
        {
            service.Find(x => x.Id == id).Name = name;
        }

  
    }
}