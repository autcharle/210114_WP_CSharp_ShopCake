using do_an_3.DataProviders;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for UserControlStatistic.xaml
    /// </summary>
    public class ElementOrder
    {
        public int idOrder { get; set; }
        public string name_customer { get; set; }
        public int totalOrderMoney { get; set; }
        public DateTime order_date { get; set; }
        public string status { get; set; }
    }

    public class CakeInThisYear
    {
        public string idCake { get; set; }
        public int quantity { get; set; }
    }


    public class CategoryElement
    {
        public string name_category { get; set; }
        public int totalMoney { get; set; }
    }


    public partial class UserControlStatistic : UserControl
    {
        List<ElementOrder> listAllOrder;
        SeriesCollection seriesMonthCollection = new SeriesCollection();
        string[] Labels = new[] {"Jan", "Feb", "Mar", "Apr", "May", "Jun",
                             "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"};

        List<CategoryElement> categoryElements;

        SeriesCollection seriesCategoryCollection = new SeriesCollection();

        // Danh sách năm 
        ObservableCollection<int> years;

        public UserControlStatistic()
        {
            InitializeComponent();

            // ------------------------------------------------
            // -------- Tính toán tổng các doanh thu ----------

            listAllOrder = new List<ElementOrder>();

            // --- Thêm dữ liệu vào danh sách listAllOrder ---
            foreach (var order in DataProvider.Ins.DB.customer_order.ToList())
            {
                string currentCustomerName = "";

                // Lấy ra tên của customer
                foreach (var cus in DataProvider.Ins.DB.customers.ToList())
                {
                    if (cus.idCustomer == order.customer_idcustomer)
                    {
                        currentCustomerName = cus.name_customer;
                        break;
                    }
                }

                // Tính tổng tiền 
                int sumAllMoney = 0;
                foreach (var cakeInOrder in DataProvider.Ins.DB.order_cake.ToList())
                {
                    if (cakeInOrder.order_idorder == order.idOrder)
                    {
                        int priceOfCake = 0;
                        // Lấy ra tiền của loại bánh kem
                        foreach (var cake in DataProvider.Ins.DB.cakes.ToList())
                        {
                            if (cakeInOrder.cake_idCake == cake.idCake)
                            {
                                priceOfCake = (int)cake.price;
                                break;
                            }
                        }
                        sumAllMoney += priceOfCake * (int)cakeInOrder.cake_quantity;
                    }
                }

                // Lấy ra order_date
                DateTime currentOrderDate = (DateTime)order.order_date;

                // Kiểm tra tình trạng 
                string currentStatus = "";

                DateTime currentTime = DateTime.Now;
                int statusTime = DateTime.Compare(currentOrderDate, currentTime);

                if (statusTime > 0)
                {
                    currentStatus = "Chưa hoàn thành";
                }
                else
                {
                    currentStatus = "Đã hoàn thành";
                }

                ElementOrder elementOrder = new ElementOrder()
                {
                    idOrder = order.idOrder,
                    name_customer = currentCustomerName,
                    totalOrderMoney = sumAllMoney,
                    order_date = currentOrderDate,
                    status = currentStatus
                };

                // Thêm vào danh sách listAllOrder
                listAllOrder.Add(elementOrder);
            }

            // Khởi tạo ComboBox
            years = new ObservableCollection<int>();
            for (int i = 1999; i <= 2021; i++)
            {
                years.Add(i);
            }

            cmbChosenYear.ItemsSource = years;

            // --------------------------------------------------
            // --------------- Khởi tạo biểu đồ cột --------------

            seriesMonthCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Values = new ChartValues<int> {},
                    Fill = Brushes.Blue
                }
            };

            chartColumn.Series = seriesMonthCollection;

            // ----------------------------------------------
            // ------------- Khởi tạo biểu đồ bánh -----------
            seriesCategoryCollection = new SeriesCollection
            {
                new PieSeries
                {
                    Values = new ChartValues<int> {},
                }
            };
            pieChartCategoryCake.Series = seriesCategoryCollection;
        }

        private void btnListAllOrder_Click(object sender, RoutedEventArgs e)
        {
            Window window = new Window() { Width = 1040, Height = 580 };
            window.Content = new UserControlListAllOrder(ref listAllOrder);
            window.Show();
        }

        private void cmbColors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbChosenYear.SelectedItem == null)
                return;

            // Lấy năm hiện tại từ ComboBox
            int chosenYear;
            try
            {
                string stringChosenYear = "2020";

                if (cmbChosenYear.SelectedItem != null)
                    stringChosenYear = cmbChosenYear.SelectedItem.ToString();

                chosenYear = Int32.Parse(stringChosenYear);
            }
            catch
            {
                chosenYear = 2020;
            }

            // Danh sách những order trong năm current
            List<customer_order> listOrderInThisYear = new List<customer_order>();

            // --------------------------------------------------
            // ----------------- Vẽ biểu đồ cột -----------------

            // Khởi tạo mảng doanh thu
            List<int> doanhThu = new List<int>() { 0, 0, 0, 0, 0, 0,
                                                   0, 0, 0, 0, 0, 0};

            // Tính doanh thu theo từng tháng 
            foreach (var order in listAllOrder)
            {
                if (order.order_date.Year == chosenYear)
                {
                    doanhThu[order.order_date.Month - 1] += order.totalOrderMoney;
                }
            }

            // Khởi tạo lại biểu đổ cột
            if (seriesMonthCollection.Count() > 0)
                if (seriesMonthCollection[0].Values != null)
                    seriesMonthCollection[0].Values.Clear();

            // Gán giá trị doanh thu vào biểu đồ
            for (int i = 0; i < 12; i++)
            {
                seriesMonthCollection[0].Values.Add(doanhThu[i]);
            }

            // --------------------------------------------------
            // ------------------ Vẽ biểu đồ bánh ---------------

            // Danh sách những cake trong năm current
            List<CakeInThisYear> cakeInThisYears = new List<CakeInThisYear>();

            foreach (var order in listAllOrder)
            {
                if (order.order_date.Year == chosenYear)
                {
                    foreach (var cakeInThisYear in DataProvider.Ins.DB.order_cake.ToList())
                    {
                        if (cakeInThisYear.order_idorder == order.idOrder)
                        {
                            cakeInThisYears.Add(new CakeInThisYear()
                            { idCake = cakeInThisYear.cake_idCake, quantity = (int)cakeInThisYear.cake_quantity });
                        }
                    }
                }
            }

            // Sau khi đã có những cake trong năm current. 
            // Ta tiến hành phân loại và tính tổng

            // Khởi tạo lại category Element
            categoryElements = new List<CategoryElement>();

            foreach (var cakeInThisYear in cakeInThisYears)
            {
                string _idCategory = "";
                string _name_category = "";

                foreach (var ca in DataProvider.Ins.DB.cakes.ToList())
                {
                    if (cakeInThisYear.idCake == ca.idCake)
                    {
                        _idCategory = ca.category_idcategory;
                        // Lấy ra tên của category
                        foreach (var cate in DataProvider.Ins.DB.categories.ToList())
                        {
                            if (_idCategory == cate.idCategory)
                            {
                                _name_category = cate.name_category;
                                break;
                            }
                        }

                        // Kiểm tra xem Category đó, đã có trong danh sách chưa 
                        bool flag = false;
                        foreach (var cate_element in categoryElements)
                        {
                            if (cate_element.name_category == _name_category)
                            {
                                cate_element.totalMoney += (int)ca.price * cakeInThisYear.quantity;
                                flag = true;
                                break;
                            }
                        }

                        // Nếu chưa có thì thêm vào
                        if (flag == false)
                        {
                            categoryElements.Add(new CategoryElement()
                            { name_category = _name_category, totalMoney = (int)ca.price * cakeInThisYear.quantity });
                        }

                        break;
                    }
                }
            }

            if (seriesCategoryCollection != null)
                seriesCategoryCollection.Clear();

            // Đưa kết quả vào pie chart
            foreach (var cate_element in categoryElements)
            {
                PieSeries newSeries = new PieSeries()
                {
                    Title = cate_element.name_category,
                    Values = new ChartValues<int> { cate_element.totalMoney }
                };
                seriesCategoryCollection.Add(newSeries);
            }
            pieChartCategoryCake.Series = seriesCategoryCollection;
        }
    }
}
