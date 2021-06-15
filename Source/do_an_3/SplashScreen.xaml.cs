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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace do_an_3
{
    /// <summary>
    /// Interaction logic for SplashScreen.xaml
    /// </summary>
    public partial class SplashScreen : Window
    {
        public class FunFact
        {
            public string Fact { get; set; }
            public string Title { get; set; }
        }

        public SplashScreen()
        {
            InitializeComponent();
            string folder = AppDomain.CurrentDomain.BaseDirectory;
            filePath = $"{folder}SplashScreenChecked.txt";
            var data = File.ReadAllText(filePath);
            if (data == "true")
            {
                MainWindow m = new MainWindow();
                m.Show();
                this.Close();
            }
            else
            {

            }
        }
        private Random _rng = new Random();
        string filePath = "";
        bool flag = true;
        const int rowsPerFact = 2;

        private void GoToMainWindowsButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            m.Show();
            this.Close();
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            var folder = AppDomain.CurrentDomain.BaseDirectory;
            filePath = $"{folder}SplashScreenChecked.txt";
            File.Create(filePath).Close();
            File.AppendAllText(filePath, "true");
        }

        private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            var folder = AppDomain.CurrentDomain.BaseDirectory;
            filePath = $"{folder}SplashScreenChecked.txt";
            File.Create(filePath).Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var folder = AppDomain.CurrentDomain.BaseDirectory;
            var filePath = $"{folder}FunFacts.txt";
            var lines = File.ReadAllLines(filePath);
            int count = int.Parse(lines[0]);

            List<FunFact> funFacts = new List<FunFact>();
            for (int i = 0; i < count; i++)
            {
                var _title = lines[i * rowsPerFact + 1];
                var _fact = lines[i * rowsPerFact + 2];

                FunFact funFact = new FunFact()
                {
                    Title = _title,
                    Fact = _fact
                };

                funFacts.Add(funFact);
            }
            var k = _rng.Next(funFacts.Count);
            TextBlock.Text = funFacts[k].Title;
            TextBox.Text = funFacts[k].Fact;
        }
    }
}
