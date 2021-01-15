using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad4Database.MyProduct
{
    public class MyCategory : ProductCategory
    {
        public MyCategory(ProductCategory category)
        {
            foreach (var property in category.GetType().GetProperties())
            {
                if (property.CanWrite)
                {
                    property.SetValue(this, property.GetValue(category));
                }
            }
        }
    }
}
