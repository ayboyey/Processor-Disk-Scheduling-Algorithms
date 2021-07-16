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
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Geared;
using LiveCharts.Defaults;

namespace lab_02_os_462
{
    public partial class MainWindow : Window
    {

        int testNr = 1;
        List<Test> tests = new List<Test>(); //this is only for estimated time
        List<Request> Disk = new List<Request>();
        int i = 1;

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        
        public ChartValues<double> Values;
        Random random = new Random();
        int temp=1;

        public MainWindow()
        {
            InitializeComponent();
            SeriesCollection = new SeriesCollection();
            Labels = new[] { "FCFS","", "SSTF", "", "SCAN", "", "CSCAN", "", "EDF", "", "FDSCAN" };

        }

        private void DownoladData()
        {
            try
            {
                Disk.Add(new Request(1, Int32.Parse(d11.Text)));
                Disk.Add(new Request(2, Int32.Parse(d12.Text)));
                Disk.Add(new Request(3, Int32.Parse(d13.Text)));
                Disk.Add(new Request(4, Int32.Parse(d14.Text)));

                Disk.Add(new Request(5, Int32.Parse(d21.Text)));
                Disk.Add(new Request(6, Int32.Parse(d22.Text)));
                Disk.Add(new Request(7, Int32.Parse(d23.Text)));
                Disk.Add(new Request(8, Int32.Parse(d24.Text)));

                Disk.Add(new Request(9, Int32.Parse(d31.Text)));
                Disk.Add(new Request(10, Int32.Parse(d32.Text)));
                Disk.Add(new Request(11, Int32.Parse(d33.Text)));
                Disk.Add(new Request(12, Int32.Parse(d34.Text)));

                Disk.Add(new Request(13, Int32.Parse(d41.Text)));
                Disk.Add(new Request(14, Int32.Parse(d42.Text)));
                Disk.Add(new Request(15, Int32.Parse(d43.Text)));
                Disk.Add(new Request(16, Int32.Parse(d44.Text)));

                Disk.Sort(new Comparator(SortOrd.ArrivalTime));

            }
            catch (FormatException e)
            {
                throw new FormatException();
            }
        }

        private void GridMouseDown(Object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //this is for closing
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //this is for how to use

            Info infoWindow = new Info();
            infoWindow.Show();

        }

        private void Ready_Click(object sender, RoutedEventArgs e)
        {
            

            foreach (Test t in tests)
            {

                SeriesCollection.Add(new LineSeries
                {
                    Title = $"Test {i}",
                    Values = new ChartValues<double> { t.getOutput()[0], Double.NaN, t.getOutput()[1], Double.NaN, t.getOutput()[2], Double.NaN, t.getOutput()[3], Double.NaN, t.getOutput()[4], Double.NaN, t.getOutput()[5] },
                    LineSmoothness = 0.5,
                    PointGeometrySize = 10,

                }); 
                i++;
            }
            DataContext = this;
            tests.Clear();
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            Disk.Clear();
            tests.Clear();
            testNr = 1;
            Add.Content = $"Add to test {testNr}";

            d11.Text = "";
            d12.Text = "";
            d13.Text = "";
            d14.Text = "";

            d21.Text = "";
            d22.Text = "";
            d23.Text = "";
            d24.Text = "";

            d31.Text = "";
            d32.Text = "";
            d33.Text = "";
            d34.Text = "";

            d41.Text = "";
            d42.Text = "";
            d43.Text = "";
            d44.Text = "";
            SeriesCollection.Clear();

        }

        private void Random_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            d11.Text = random.Next(0, 50).ToString();
            d12.Text = random.Next(0, 50).ToString();
            d13.Text = random.Next(0, 50).ToString();
            d14.Text = random.Next(0, 50).ToString();

            d21.Text = random.Next(0, 50).ToString();
            d22.Text = random.Next(0, 50).ToString();
            d23.Text = random.Next(0, 50).ToString();
            d24.Text = random.Next(0, 50).ToString();

            d31.Text = random.Next(0, 50).ToString();
            d32.Text = random.Next(0, 50).ToString();
            d33.Text = random.Next(0, 50).ToString();
            d34.Text = random.Next(0, 50).ToString();

            d41.Text = random.Next(0, 50).ToString();
            d42.Text = random.Next(0, 50).ToString();
            d43.Text = random.Next(0, 50).ToString();
            d44.Text = random.Next(0, 50).ToString();

        }

        private void Add_to_test(object sender, RoutedEventArgs e)
        {
            try
            {
                DownoladData();
                this.temp = random.Next(1, 16);
                FCFS fcfs = new FCFS(copy(Disk),temp);
                SSTF sstf = new SSTF(copy(Disk), temp);
                SCAN scan = new SCAN(copy(Disk), temp);
                CSCAN cscan = new CSCAN(copy(Disk), temp);
                EDF edf = new EDF(copy(Disk), temp);
                FDSCAN fdscan = new FDSCAN(copy(Disk), temp);

                tests.Add(new Test(fcfs.Run(), sstf.Run(), scan.Run(), cscan.Run(), edf.Run(), fdscan.Run())); ///////////fix this input TODO

                Disk.Clear();
                testNr++;
                Add.Content = $"Add to test {testNr}";
            }
            catch (FormatException e2)
            {
                Error inputfailed = new Error();
                inputfailed.Show();
            }

        }

        private List<Request> copy(List<Request> toCopy)
        {
            List<Request> copy = new List<Request>();

            foreach (Request r in toCopy)
            {
                copy.Add(new Request(r.idx, r.arrival));
            }
            return copy;
        }

        
    }
}
