using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad4XMLBinding.Models
{
    public class SubCategory
    {
        public string Name { get; set; }
        public string ParentCategory { get; set; }
        public string Description { get; set; }
        public List<Car> Cars { get; set; }
    }
}
