using do_an_3.DataProviders;
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
    /// Interaction logic for UserControlAddCakeToOrder.xaml
    /// </summary>
    public partial class UserControlAddCakeToOrder : UserControl
    {
        AllOrder allOrder;
        private CakeInOrder newCake;

        public UserControlAddCakeToOrder(ref AllOrder _allOrder)
        {
            InitializeComponent();
            this.allOrder = _allOrder;

            cmbCake.ItemsSource = DataProvider.Ins.DB.cakes.ToList();
        }

        private void txtQuantity_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = sender as TextBox;

            // Get selected cake in combox box
            var selectedCake = (cake)cmbCake.SelectedItem;
            int priceOfCake = (int)selectedCake.price;

            try
            {
                lbTotalPrice.Content = Int32.Parse(tb.Text) * priceOfCake;
            }
            catch { }

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            // Get selected cake in combox box
            var selectedCake = (cake)cmbCake.SelectedItem;

            newCake = new CakeInOrder();

            newCake.name_cake = selectedCake.name_cake;
            newCake.price = (int)selectedCake.price;
            newCake.quantity = Int32.Parse(txtQuantity.Text);
            newCake.totalPrice = newCake.quantity * newCake.price;

            // Thêm newCake vào danh sách
            this.allOrder.listCake.Add(newCake);

            // Thông báo đã thêm thành công 
            MessageBox.Show("Đã thêm bánh vào đơn đặt hàng !");
        }
    }
}
