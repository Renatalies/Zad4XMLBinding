using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad4XMLBinding.Models
{
    public class Category
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<SubCategory> SubCategories { get; set; }
    }
}
