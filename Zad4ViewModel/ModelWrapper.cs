using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zad4Model;

namespace Zad4ViewModel
{
    public class ModelWrapper : IModelWrapper
    {
        private IModel service;

        public ModelWrapper()
        {
            this.service = new Model();
        }

        public void AddProductCategory(string name, string date)
        {
            service.AddProductCategory(name, date);
        }
        public void DeleteProductCategory(int id)
        {
            try
            {
                service.DeleteProductCategory(id);
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw e;
            }
        }
        public List<MyCategory> GetAllProductCategories()
        {
            return service.GetAllProductCategories().Select(c => new MyCategory(c.Id, c.Name, c.Date)).ToList();
        }

        public List<MyCategory> GetMyProductCategoryById(int id)
        {
            return service.GetMyProductCategoryById(id).Select(c => new MyCategory(c.Id, c.Name, c.Date)).ToList();
        }
        public List<MyCategory> GetMyProductCategoryByName(string name)
        {
            return service.GetMyProductCategoryByName(name).Select(c => new MyCategory(c.Id, c.Name, c.Date)).ToList();
        }
        public void UpdateProductCategory(string name, int id)
        {
            service.UpdateProductCategory(name, id);
        }
    }
}
