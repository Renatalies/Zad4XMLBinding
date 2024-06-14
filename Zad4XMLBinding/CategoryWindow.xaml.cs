using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Zad4XMLBinding.Models;
using Zad4XMLBinding.ViewModels;

namespace Zad4XMLBinding
{
    /// <summary>
    /// Logika interakcji dla klasy CategoryWindow.xaml
    /// </summary>
    public partial class CategoryWindow : Window
    {
        public CategoryWindow(Category category)
        {
            InitializeComponent();
            DataContext = new CategoryViewModel(category);
        }
    }
}
