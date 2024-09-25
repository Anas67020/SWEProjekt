using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using TradeUnrepublic;

namespace WpfAppTest
{
    abstract class Wertpapier
    {
        private string namen;
        public string Namen
        {
            get { return namen; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Name nicht angegeben!");
                }
                namen = value;
            }
        }

        private int isin;
        public int ISIN
        {
            get { return isin; }
            set
            {
                if (value == 0)
                {
                    throw new Exception("ISIN nicht angegeben!");
                }
                isin = value;
            }
        }

        private List<Kurs> kurse;
        public List<Kurs> Kurse => kurse;

        public Wertpapier(string _namen, int _isin)
        {
            ISIN = _isin;
            Namen = _namen;
            kurse = new List<Kurs>();
        }

        protected Wertpapier() { }

        // Displays the latest stock prices by fetching them asynchronously
        public async void AnzeigenKurs()
        {
            await AddKurs();
        }

        // Fetch stock data and add the latest Kurs instance to the list
        public async Task AddKurs()
        {
            try
            {
                Kurs kurs = new Kurs();
                await kurs.FetchStockDataAsync(Namen);  // Assuming Namen is used as the stock symbol

                if (kurs.Werte.Count > 0)
                {
                    kurse.Add(kurs); // Add the Kurs instance to the list
                    MessageBox.Show($"Stock data added for {Namen}. Last Close: {kurs.Werte[1]:C}");
                }
                else
                {
                    MessageBox.Show($"No data available for {Namen}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching stock data for {Namen}: {ex.Message}");
            }
        }
    }
}
