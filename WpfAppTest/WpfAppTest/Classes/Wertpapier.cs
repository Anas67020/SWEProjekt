using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TradeUnrepublic;

namespace WpfAppTest
{
    abstract class Wertpapier
    {
        public List<string> DailyPrices;
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
        public List<Kurs> Kurse
        {
            get { return kurse; }
        }
        public Wertpapier(string _namen, int _isin)
        {
            ISIN = _isin;
            Namen = _namen;

        }

        protected Wertpapier()
        {
        }

        public void AnzeigenKurs()
        {
            AddKurs();
        }
        //das pakage das für diese anwendungen installiert werden muss ist das: Install-Package Newtonsoft.Json
        //sorgt dafür die werte aus der Api zu holfen und sie auf der GUI auszugeben
        // kann aber nicht testen, weil ich da pakage irgendwie nicht downloaden kann 
        public void WerteHolen()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    // API URL
                    var apiUrl = "http://alphavantage.co/query?function=TIME_SERIES_DAILY&symbol=IBM&apikey=demo";

                    // Send a synchronous GET request to the API
                    HttpResponseMessage response = client.GetAsync(apiUrl).Result;

                    // Ensure the request was successful
                    response.EnsureSuccessStatusCode();

                    // Read the response content as a string (blocking call)
                    string jsonResponse = response.Content.ReadAsStringAsync().Result;

                    // Deserialize the JSON string to your 'Properties' object
                    Properties deserialized = JsonConvert.DeserializeObject<Properties>(jsonResponse);

                    // Assuming 'Properties' has a collection 'DailyPrices', iterate through it
                    if (deserialized != null && deserialized.DailyPrices != null)
                    {
                        DailyPrices = deserialized.DailyPrices.Select(dp => dp.Date + ": " + dp.Price).ToList();

                        // Print or use the prices in the UI
                        foreach (var price in DailyPrices)
                        {
                            Console.WriteLine(price);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data available or deserialization failed.");
                    }
                }
            }
            catch (HttpRequestException httpRequestException)
            {
                Console.WriteLine("Error fetching data from API: " + httpRequestException.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }


        // hier müssten eigentlich die daten aus der werteholenmethode ausgegeben werden, wenn ich alles richtig gemacht habe
        public void AddKurs()
        {
            WerteHolen();// mit angegebenem Koordinatensystem eigentlich
        }
        //dazu da das format zu bestimmen der json datei und das man auch in diesem Format auf die Sachen aus der Api und der json datei zugreifen kann
        public class DailyPrice
        {
            public string Date { get; set; }
            public decimal Price { get; set; }
        }

        public class Properties
        {
            public List<DailyPrice> DailyPrices { get; set; }
        }


    }
}