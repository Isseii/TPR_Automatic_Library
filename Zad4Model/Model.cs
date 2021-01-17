using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zad4Service;

namespace Zad4Model
{
    public class Model : IModel
    {
        private IMyCategoryService service;

        public Model()
        {
            service = new MyCategoryService();
        }

        public void AddProductCategory( string name, string date)
        {
            service.AddProductCategory( name, date);
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
