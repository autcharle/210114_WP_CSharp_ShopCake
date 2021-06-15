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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace do_an_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = new UserControlHome();
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new UserControlHome();
        }

        private void btnAddCake_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new UserControlAddProduct();
        }

        private void btnStatistic_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new UserControlStatistic();
        }

        private void btnAddOrder_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new UserControlAddOrder();
        }

        private void btnOpenMenu_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
