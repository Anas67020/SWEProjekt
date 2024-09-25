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

        Kurs kurs = new Kurs();

        public PageTwo()
        {
            InitializeComponent();

            // Initialize chart data
            InitializeChartData();

            // Dispatcher timer for real-time updates
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(10); // Set interval for real-time updates
            timer.Tick += Timer_Tick; // Assign event handler
            timer.Start();
        }

        // Initialize chart with initial data
        private void InitializeChartData()
        {
            // Fetch initial data from the API
            kurs.WerteHolen();

            // Assuming that 'Werte' contains stock prices and 'Daten' contains corresponding dates
            if (kurs.Werte != null && kurs.Werte.Count > 0 && kurs.DailyPrices != null)
            {
                // Create chart values from the fetched data
                var stockPrices = new ChartValues<double>(kurs.Werte);
                DateLabels = kurs.DailyPrices.Select(dp => dp.Split(':')[0]).ToList(); // Extract dates from the API response

                // Create the line series for stock prices
                StockPricesSeries = new SeriesCollection
                {
                    new LineSeries
                    {
                        Title = "Stock Prices",
                        Values = stockPrices,
                        PointGeometrySize = 15,
                        DataLabels = true,
                        LabelPoint = point => $"Date: {DateLabels[(int)point.X]} \nPrice: {point.Y:C}"
                    }
                };

                // Configure X-axis (dates)
                DateAxis = new Axis
                {
                    Title = "Date",
                    Labels = DateLabels
                };

                // Configure Y-axis (stock prices)
                PriceAxis = new Axis
                {
                    Title = "Price ($)",
                    LabelFormatter = value => value.ToString("C")
                };

                // Set DataContext to allow binding
                DataContext = this;
            }
            else
            {
                Console.WriteLine("No initial data found.");
            }
        }

        // Event handler for the DispatcherTimer's Tick event (called every 10 seconds)
        private async void Timer_Tick(object sender, EventArgs e)
        {
            // Fetch new stock data
            await FetchAndUpdateChart();
        }

        // Fetch real-time data and update the chart
        private async Task FetchAndUpdateChart()
        {
            try
            {
                // Fetch the latest stock prices from the API
                kurs.WerteHolen();

                // Check if new data is available
                if (kurs.Werte != null && kurs.Werte.Count > 0 && kurs.DailyPrices != null)
                {
                    // Add new data points to the chart
                    foreach (var newPrice in kurs.Werte)
                    {
                        StockPricesSeries[0].Values.Add(newPrice);
                    }

                    // Update DateLabels with new dates
                    foreach (var dailyPrice in kurs.DailyPrices)
                    {
                        string date = dailyPrice.Split(':')[0]; // Extract date from API response
                        DateLabels.Add(date);
                    }

                    // Update DateAxis labels to reflect new dates
                    DateAxis.Labels = DateLabels;

                    // Re-render the chart
                    DataContext = null;  // Temporarily unset the DataContext
                    DataContext = this;   // Reset the DataContext to trigger UI updates
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching and updating chart data: {ex.Message}");
            }
        }
    }
}
