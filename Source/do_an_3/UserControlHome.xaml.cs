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
using do_an_3.Paging;

namespace do_an_3
{
    /// <summary>
    /// Interaction logic for UserControlHome.xaml
    /// </summary>
    public partial class UserControlHome : UserControl
    {
        const int cakesPerPage = 10;
        Paging.Paging _paging;
        List<cake> _cakes;

        public UserControlHome()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                ShopCakeEntities db = new ShopCakeEntities();
                CategoriesComboBox.ItemsSource = db.categories.ToList();

                CalculatePagingInfo_GetAll();
                DisplayAllProducts();
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                return;
            }
        }

        private void ClearFilterButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CategoriesComboBox.SelectedItem = null;
            ClearFilterButton.Visibility = Visibility.Collapsed;
        }

        private void CategoriesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ClearFilterButton.Visibility == Visibility.Collapsed)
            ClearFilterButton.Visibility = Visibility.Visible;

            if(CategoriesComboBox.SelectedItem == null)
            {
                CalculatePagingInfo_GetAll();
                DisplayAllProducts();
            }
            else
            {
                CalculatePagingInfo();
                DisplayProducts();
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            int index = PagingInfoComboBox.SelectedIndex;
            if (index == _paging.TotalPages - 1)
            {

            }
            else
            {
                PagingInfoComboBox.SelectedIndex += 1;
            }
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            int index = PagingInfoComboBox.SelectedIndex;
            if (index == 0)
            {

            }
            else
            {
                PagingInfoComboBox.SelectedIndex -= 1;
            }
        }

        void CalculatePagingInfo_GetAll()
        {
            ShopCakeEntities db = new ShopCakeEntities();
            var keyword = SearchTextBox.Text;
            var query = from c in db.cakes
                        where c.name_cake.Contains(keyword)
                        select c;
            var count = query.Count();
            var rowsPerPage = cakesPerPage;

            // Tinh toan phan trang
            _paging = new Paging.Paging()
            {
                CurrentPage = 1,
                RowsPerPage = cakesPerPage,
                TotalPages = count / rowsPerPage +
                    (((count % rowsPerPage) == 0) ? 0 : 1)
            };

            PagingInfoComboBox.ItemsSource = _paging.Pages;
            PagingInfoComboBox.SelectedIndex = 0;
        }

        void CalculatePagingInfo()
        {
            var category = CategoriesComboBox.SelectedItem
                as category;

            // Truy van
            var keyword = SearchTextBox.Text;
            var query = from c in category.cakes
                        where c.name_cake.Contains(keyword)
                        select c;
            var count = query.Count();
            var rowsPerPage = cakesPerPage;

            // Tinh toan phan trang
            _paging = new Paging.Paging()
            {
                CurrentPage = 1,
                RowsPerPage = cakesPerPage,
                TotalPages = count / rowsPerPage +
                    (((count % rowsPerPage) == 0) ? 0 : 1)
            };

            PagingInfoComboBox.ItemsSource = _paging.Pages;
            PagingInfoComboBox.SelectedIndex = 0;
        }

        void DisplayAllProducts()
        {
            if (PagingInfoComboBox.SelectedIndex < 0)
            {
                PagingInfoComboBox.SelectedIndex = 0;
            }

            var page = PagingInfoComboBox.SelectedIndex + 1;
            ShopCakeEntities db = new ShopCakeEntities();
            var rowsPerPage = cakesPerPage;
            var skip = (page - 1) * rowsPerPage;
            var take = rowsPerPage;

            var keyword = SearchTextBox.Text;

            var query = from p in db.cakes
                        where p.name_cake.Contains(keyword)
                        select p;

            _cakes = query.OrderBy(c => c.name_cake)
                .Skip(skip).Take(take)
                .ToList();
            ListBoxCakes.ItemsSource = _cakes;
        }

        void DisplayProducts()
        {
            var page = PagingInfoComboBox.SelectedIndex + 1;
            var category = CategoriesComboBox.SelectedItem
                as category;
            var rowsPerPage = cakesPerPage;
            var skip = (page - 1) * rowsPerPage;
            var take = rowsPerPage;

            var keyword = SearchTextBox.Text;

            var query = from p in category.cakes
                        where p.name_cake.Contains(keyword)
                        select p;

            _cakes = query
                .Skip(skip).Take(take)
                .ToList();
            ListBoxCakes.ItemsSource = _cakes;
        }

        private void PagingInfoComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CategoriesComboBox.SelectedItem == null)
                DisplayAllProducts();
            else
                DisplayProducts();
        }

        private void ListBoxCakes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Panel.Children.Clear();
            Panel.Children.Add(new UserControlDetails(_cakes[ListBoxCakes.SelectedIndex]));
        }

        private void SearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (CategoriesComboBox.SelectedItem == null)
                {
                    CalculatePagingInfo_GetAll();
                    DisplayAllProducts();
                }
                    
                else
                {
                    CalculatePagingInfo();
                    DisplayProducts();
                }
            }
        }
    }
}
