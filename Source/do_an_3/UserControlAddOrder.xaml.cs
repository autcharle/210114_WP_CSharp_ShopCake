using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using do_an_3.DataProviders;

namespace do_an_3
{
    /// <summary>
    /// Interaction logic for UserControlAddOrder.xaml
    /// </summary>
    // Class about cake 
    public class CakeInOrder : INotifyPropertyChanged
    {
        // Tên bánh
        private string _name_cake;
        public string name_cake
        {
            get { return this._name_cake; }
            set
            {
                if (this._name_cake != value)
                {
                    this._name_cake = value;
                    this.NotifyPropertyChanged("name_cake");
                }
            }
        }

        // Giá 
        private int _price;
        public int price
        {
            get { return this._price; }
            set
            {
                if (this._price != value)
                {
                    this._price = value;
                    this.NotifyPropertyChanged("price");
                }
            }
        }

        // Sô lượng 
        private int _quantity;
        public int quantity
        {
            get { return this._quantity; }
            set
            {
                if (this._quantity != value)
                {
                    this._quantity = value;
                    this.NotifyPropertyChanged("quantity");
                }
            }
        }
        // Tổng tiền
        private long _totalPrice;
        public long totalPrice
        {
            get { return this._totalPrice; }
            set
            {
                if (this._totalPrice != value)
                {
                    this._totalPrice = value;
                    this.NotifyPropertyChanged("totalPrice");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }

    // Class about list of cake
    public class AllOrder : INotifyPropertyChanged
    {
        private ObservableCollection<CakeInOrder> _listCake;

        public ObservableCollection<CakeInOrder> listCake
        {
            get { return _listCake; }
            set
            {
                _listCake = value;
                NotifyPropertyChanged("listCake");
                NotifyPropertyChanged("listCakeSumPrice");
                _listCake.CollectionChanged += delegate
                {
                    NotifyPropertyChanged("listCakeSumPrice");
                };

                foreach (CakeInOrder cake in _listCake)
                {
                    cake.PropertyChanged += (sender, e) =>
                    {
                        if (e.PropertyName == "totalPrice")
                        {
                            NotifyPropertyChanged("listCakeSumPrice");
                        }
                    };
                }
            }
        }
        public long listCakeSumPrice
        {
            get
            {
                long sum = 0;
                foreach (CakeInOrder cake in _listCake)
                {
                    sum += cake.totalPrice;
                }
                return sum;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public partial class UserControlAddOrder : UserControl
    {
        public ObservableCollection<CakeInOrder> listCakeInOrder;

        public AllOrder allOrder;

        public UserControlAddOrder()
        {
            InitializeComponent();

            allOrder = new AllOrder() { listCake = new ObservableCollection<CakeInOrder>() };
            this.DataContext = allOrder;

            lvCakeOfOrder.ItemsSource = allOrder.listCake;
        }


        private void btnAddCakeToOrder_Click(object sender, RoutedEventArgs e)
        {
            Window window = new Window() { Width = 300, Height = 200 };
            window.Content = new UserControlAddCakeToOrder(ref this.allOrder);
            window.Show();
        }

        private void txtShipFee_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = sender as TextBox;

            try
            {
                int shipFee = Int32.Parse(tb.Text);

                lblAllMoney.Content = Int32.Parse(lblAllOrder.Content.ToString()) +
                                        shipFee;
            }
            catch { }
        }

        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            bool isExistCustomer = false;

            int currentIdCustomer = -1;
            int currentIdOrder = -1;

            // Kiểm tra ngày tạo đơn có đúng không 
            DateTime dateCreateOrder;
            try
            {
                dateCreateOrder = DateTime.ParseExact(txtDay.Text, "MM/dd/yyyy",
                                       System.Globalization.CultureInfo.InvariantCulture);
            }
            catch
            {
                MessageBox.Show("Nhập ngày bắt đầu sai định dạng. (MM/dd/yyyy)");
                return;
            }

            // Kiểm tra xem customer có trong database customer chưa
            foreach (var cus in DataProvider.Ins.DB.customers.ToList())
            {
                if (cus.name_customer == txtNameCustomer.Text)
                {
                    isExistCustomer = true;
                    currentIdCustomer = cus.idCustomer;
                }
            }

            // Nếu customer chưa có trong database customer
            if (isExistCustomer == false)
            {
                // Tạo customer mới
                customer newCustomer = new customer()
                {
                    idCustomer = DataProvider.Ins.DB.customers.Count() + 1,
                    name_customer = txtNameCustomer.Text,
                    phone = txtPhoneCustomer.Text
                };

                currentIdCustomer = DataProvider.Ins.DB.customers.Count() + 1;

                // Thêm customer vào database
                DataProvider.Ins.DB.customers.Add(newCustomer);
                DataProvider.Ins.DB.SaveChanges();
            }

            // -------------------------------------------------------
            // ---------- CẬP NHẬT DATABASE CUSTOMER_ORDER -----------

            // Tạo Order mới
            customer_order newOrder = new customer_order()
            {
                idOrder = DataProvider.Ins.DB.customer_order.Count() + 1,
                customer_idcustomer = currentIdCustomer,
                order_date = dateCreateOrder
            };

            currentIdOrder = DataProvider.Ins.DB.customer_order.Count() + 1;

            // Thêm Order vào database
            DataProvider.Ins.DB.customer_order.Add(newOrder);
            DataProvider.Ins.DB.SaveChanges();


            // -------------------------------------------------------
            // ------------- CẬP NHẬT DATABASE ORDER_CAKE ------------

            // Duyệt lần lượt các cake trong danh sách
            foreach (var cake in allOrder.listCake)
            {
                // Tìm id cake
                string currentIdCake = "";

                foreach (var ca in DataProvider.Ins.DB.cakes.ToList())
                {
                    if (ca.name_cake == cake.name_cake)
                    {
                        currentIdCake = ca.idCake;
                    }
                }


                // Tạo cake_order mới
                order_cake newOrderCake = new order_cake()
                {
                    id = DataProvider.Ins.DB.order_cake.Count() + 1,
                    order_idorder = currentIdOrder,
                    cake_idCake = currentIdCake,
                    cake_quantity = cake.quantity
                };

                // Thêm cake_order vào database
                DataProvider.Ins.DB.order_cake.Add(newOrderCake);
                DataProvider.Ins.DB.SaveChanges();
            }

            MessageBox.Show("Tạo đơn thành công !");
        }
    }
}
