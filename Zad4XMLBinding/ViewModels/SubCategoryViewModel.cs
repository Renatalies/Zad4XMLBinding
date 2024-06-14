using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zad4XMLBinding.Models;

namespace Zad4XMLBinding.ViewModels
{
    public class SubCategoryViewModel
    {
        public SubCategory SelectedSubCategory { get; set; }
        public ObservableCollection<Car> Cars { get; set; }

        public SubCategoryViewModel(SubCategory subCategory)
        {
            SelectedSubCategory = subCategory;
            Cars = new ObservableCollection<Car>(subCategory.Cars);
        }
    }
}
