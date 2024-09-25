using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using WpfAppTest;

namespace TradeUnrepublic
{
    public partial class PageTwo : Page
    {
        public SeriesCollection StockPricesSeries { get; set; }
        public List<string> DateLabels { get; set; }
        public Axis DateAxis { get; set; }
        public Axis PriceAxis { get; set; }

        private Kurs kurs = new Kurs();

        public PageTwo()
        {
            InitializeComponent();
            InitializeChartData();
            var timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(10)
            };
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private async void InitializeChartData()
        {
            try
            {
                await kurs.FetchStockDataAsync();  // Fetch stock data asynchronously

                if (kurs.Werte.Count > 0)
                {
                    StockPricesSeries = new SeriesCollection
                {
                    new LineSeries
                    {
                        Title = "Stock Prices",
                        Values = new ChartValues<double>(kurs.Werte),
                        PointGeometrySize = 10,
                        DataLabels = true
                    }
                };

                    DateLabels = kurs.DailyPrices;

                    DateAxis = new Axis { Title = "Date", Labels = DateLabels };
                    PriceAxis = new Axis { Title = "Price ($)", LabelFormatter = value => value.ToString("C") };

                    DataContext = this;
                }
                else
                {
                    MessageBox.Show("No data available.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing chart: {ex.Message}");
            }
        }

        private async void Timer_Tick(object sender, EventArgs e)
        {
            await kurs.FetchStockDataAsync();  // Fetch new data asynchronously
            UpdateChartData();
        }

        private void UpdateChartData()
        {
            StockPricesSeries[0].Values.Clear();
            foreach (var value in kurs.Werte)
            {
                StockPricesSeries[0].Values.Add(value);
            }

            DateAxis.Labels = kurs.DailyPrices;
            DataContext = null;
            DataContext = this;
        }
    }

}
