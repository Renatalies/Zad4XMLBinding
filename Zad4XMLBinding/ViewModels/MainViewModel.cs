using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;
using Zad4XMLBinding;
using Zad4XMLBinding.Models;

namespace Zad4XMLBinding.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<Category> Categories { get; set; }
        public Category SelectedCategory { get; set; }
        public ICommand OpenCategoryCommand { get; }

        public MainViewModel()
        {
            Categories = new ObservableCollection<Category>();

            LoadData();

            OpenCategoryCommand = new RelayCommand(OpenCategory, CanOpenCategory);
        }

        private void LoadData()
        {
            string xmlData = File.ReadAllText("Cars.xml");
            XDocument doc = XDocument.Parse(xmlData);

            var categories = doc.Descendants("Category")
                                .Select(c => new Category
                                {
                                    Name = c.Element("Name").Value,
                                    Description = c.Element("Description").Value,
                                    SubCategories = c.Descendants("SubCategory")
                                                     .Select(sc => new SubCategory
                                                     {
                                                         Name = sc.Element("Name").Value,
                                                         ParentCategory = sc.Element("ParentCategory").Value,
                                                         Description = sc.Element("Description").Value,
                                                         Cars = sc.Descendants("Car")
                                                                      .Select(v => new Car
                                                                      {
                                                                          Model = v.Element("Model").Value,
                                                                          Year = int.Parse(v.Element("Year").Value),
                                                                          EngineCapacity = double.Parse(v.Element("EngineCapacity").Value, new CultureInfo("EN")),
                                                                          DriveType = v.Element("DriveType").Value
                                                                      }).ToList()
                                                     }).ToList()
                                }).ToList();

            foreach (var category in categories)
            {
                Categories.Add(category);
            }
        }

        private void OpenCategory(object parameter)
        {
            if (SelectedCategory != null)
            {
                var categoryWindow = new CategoryWindow(SelectedCategory);
                categoryWindow.Show();
            }
        }

        private bool CanOpenCategory(object parameter)
        {
            return SelectedCategory != null;
        }
    }
}
