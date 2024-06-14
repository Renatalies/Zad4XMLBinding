using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Zad4XMLBinding;
using Zad4XMLBinding.Models;

namespace Zad4XMLBinding.ViewModels
{
    public class CategoryViewModel
    {
        public Category SelectedCategory { get; set; }
        public SubCategory SelectedSubCategory { get; set; }
        public ObservableCollection<SubCategory> SubCategories { get; set; }
        public ICommand OpenSubCategoryCommand { get; }

        public CategoryViewModel(Category category)
        {
            SelectedCategory = category;
            SubCategories = new ObservableCollection<SubCategory>(category.SubCategories);

            OpenSubCategoryCommand = new RelayCommand(OpenSubCategory, CanOpenSubCategory);
        }

        private void OpenSubCategory(object parameter)
        {
            if (SelectedSubCategory != null)
            {
                var subCategoryWindow = new SubCategoryWindow(SelectedSubCategory);
                subCategoryWindow.Show();
            }
        }

        private bool CanOpenSubCategory(object parameter)
        {
            return SelectedSubCategory != null;
        }
    }
}
