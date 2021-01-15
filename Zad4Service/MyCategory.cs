using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad4Service
{
    public class MyCategory
    {
        public int Id { get; set; }
        public String Name { get; set; }

        public DateTime Date { get; set; }

        public MyCategory(int id, string name, DateTime date)
        {
            Id = id;
            Name = name;
            Date = date;
        }
    }
}
