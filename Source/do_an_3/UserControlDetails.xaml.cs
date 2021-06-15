using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for UserControlDetails.xaml
    /// </summary>
    public partial class UserControlDetails : UserControl
    {
        cake _cake;
        public UserControlDetails(cake cake)
        {
            InitializeComponent();
            _cake = cake;

            DataContext = _cake;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ShopCakeEntities db = new ShopCakeEntities();
            NameCategoryTextBox.Text = db.categories.Find(IDCategoryTextBox.Text).name_category.ToString();
            CategoriesComboBox.ItemsSource = db.categories.ToList();
            CategoriesComboBox.SelectedItem = db.categories.Find(IDCategoryTextBox.Text);
            CategoriesComboBox.IsEnabled = false;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            NameCakeTextBox.IsReadOnly = false;
            IDTextBox.IsReadOnly = false;
            QuantityTextBox.IsReadOnly = false;
            CostTextBox.IsReadOnly = false;
            PriceTextBox.IsReadOnly = false;
            DescriptionTextBox.IsReadOnly = false;
            IDCategoryTextBox.IsReadOnly = false;
            NameCategoryTextBox.IsReadOnly = false;
            CategoriesComboBox.IsEnabled = true;

            if (AddCategoryButton.Visibility == Visibility.Collapsed)
            ChooseCategoryButton.Visibility = Visibility.Visible;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            NameCakeTextBox.IsReadOnly = true;
            IDTextBox.IsReadOnly = true;
            QuantityTextBox.IsReadOnly = true;
            CostTextBox.IsReadOnly = true;
            PriceTextBox.IsReadOnly = true;
            DescriptionTextBox.IsReadOnly = true;
            CategoriesComboBox.IsEnabled = false;

            AddCategoryButton.Visibility = Visibility.Collapsed;
            ChooseCategoryButton.Visibility = Visibility.Collapsed;

            try
            {
                ShopCakeEntities db = new ShopCakeEntities();
                var cake = db.cakes.Find(_cake.idCake);
                cake.image = _cake.image;
                cake.name_cake = _cake.name_cake;
                cake.cost = _cake.cost;
                cake.price = _cake.price;
                cake.category_idcategory = _cake.category_idcategory;
                cake.description = _cake.description;

                if (CategoriesComboBox.Visibility == Visibility.Visible)
                {
                    
                }
                else
                {
                    var category = new category()
                    {
                        idCategory = IDCategoryTextBox.Text,
                        name_category = NameCategoryTextBox.Text
                    };
                    try
                    {
                        if(db.categories.Find(category.idCategory) == null )
                        {
                            db.categories.Add(category);
                            db.SaveChanges();
                        }
                        _cake.category_idcategory = IDCategoryTextBox.Text;
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message);
                        return;
                    }
                }

                cake.category_idcategory = _cake.category_idcategory;
                db.SaveChanges();
                MessageBox.Show("Chỉnh sửa thành công ^_^");
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                return;
            }

        }

        private void EditImageButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            BitmapImage image;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                Uri imageUri = new Uri(openFileDialog.FileName);
                image = new BitmapImage(imageUri);
                ImageCake.Source = image;

                var encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(image));

                using (var stream = new MemoryStream())
                {
                    // Chuyen sang mang byte
                    encoder.Save(stream);

                    _cake.image = stream.ToArray();
                }
            }
        }

        private void AddCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            CategoriesComboBox.Visibility = Visibility.Collapsed;
            CategoryTextBox.Visibility = Visibility.Visible;

            AddCategoryButton.Visibility = Visibility.Collapsed;
            ChooseCategoryButton.Visibility = Visibility.Visible;
        }

        private void ChooseCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            CategoriesComboBox.Visibility = Visibility.Visible;
            CategoryTextBox.Visibility = Visibility.Collapsed;

            AddCategoryButton.Visibility = Visibility.Visible;
            ChooseCategoryButton.Visibility = Visibility.Collapsed;
        }

        private void CategoriesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var _category = CategoriesComboBox.SelectedItem as category;
            _cake.category_idcategory = _category.idCategory;
        }
    }
}
