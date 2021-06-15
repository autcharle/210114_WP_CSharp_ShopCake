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
    /// Interaction logic for UserControlListAllOrder.xaml
    /// </summary>
    public partial class UserControlListAllOrder : UserControl
    {
        List<ElementOrder> listAllOrder;
        public UserControlListAllOrder(ref List<ElementOrder> _listAllOrder)
        {
            InitializeComponent();

            listAllOrder = _listAllOrder;

            lvListAllOrder.ItemsSource = listAllOrder;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvListAllOrder.ItemsSource);
            view.Filter = UserFilter;
        }

        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(txtFilter.Text))
                return true;
            else
                return ((item as ElementOrder).name_customer.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void txtFilter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(lvListAllOrder.ItemsSource).Refresh();
        }
    }
}
