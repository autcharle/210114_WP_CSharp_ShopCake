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
    /// Interaction logic for UserControlAddProduct.xaml
    /// </summary>
    public partial class UserControlAddProduct : UserControl
    {
        cake _newCake;
        public UserControlAddProduct()
        {
            InitializeComponent();

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

                //Lưu ảnh
                var encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(image));

                using (var stream = new MemoryStream())
                {
                    // Chuyển sang mảng byte
                    encoder.Save(stream);

                    _newCake.image = stream.ToArray();
                }
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (IDTextBox.Text == null)
            {
                MessageBox.Show("Vui lòng nhập ID sản phẩm");
                return;
            }

            if (IDCategoryTextBox.Text == null && CategoryTextBox.Visibility == Visibility.Visible)
            {
                MessageBox.Show("Vui lòng nhập Loại sản phẩm");
                return;
            }

            try
            {
                ShopCakeEntities db = new ShopCakeEntities();

                if(CategoryTextBox.Visibility == Visibility.Visible)
                {
                    var category = new category()
                    {
                        idCategory = IDCategoryTextBox.Text,
                        name_category = NameCategoryTextBox.Text
                    };

                    db.categories.Add(category);
                    db.SaveChanges();

                    _newCake.category_idcategory = IDCategoryTextBox.Text;
                }
                else
                {
                    var _category = CategoriesComboBox.SelectedItem
                    as category;
                    _newCake.category_idcategory = _category.idCategory;
                }

                _newCake.idCake = IDTextBox.Text;
                _newCake.name_cake = NameCakeTextBox.Text;
                _newCake.cost = int.Parse(CostTextBox.Text);
                _newCake.price = int.Parse(PriceTextBox.Text);
                _newCake.quantity = int.Parse(QuantityTextBox.Text);
                _newCake.description = DescriptionTextBox.Text;

                db.cakes.Add(_newCake);
                db.SaveChanges();
                MessageBox.Show("Thêm sản phẩm thành công");
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                return;
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
            AddCategoryButton.Visibility = Visibility.Visible;
            ChooseCategoryButton.Visibility = Visibility.Collapsed;

            CategoriesComboBox.Visibility = Visibility.Visible;
            CategoryTextBox.Visibility = Visibility.Collapsed;
        }

        private void RenewButton_Click(object sender, RoutedEventArgs e)
        {
            DescriptionTextBox.Text = "";
            IDTextBox.Text = "";
            QuantityTextBox.Text = "";
            NameCakeTextBox.Text = "";
            CategoriesComboBox.SelectedItem = null;
            CostTextBox.Text = "";
            PriceTextBox.Text = "";
            IDCategoryTextBox.Text = "";
            NameCategoryTextBox.Text = "";
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _newCake = new cake();

            ShopCakeEntities db = new ShopCakeEntities();
            CategoriesComboBox.ItemsSource = db.categories.ToList();
        }
    }
}
