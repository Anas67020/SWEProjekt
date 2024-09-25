using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static WpfAppTest.Wertpapier;

namespace WpfAppTest
{
    internal class Kurs
    {
        public List<string> DailyPrices;
        private List<double> werte;
        public List<double> Werte {get;set;}
        private DateTime daten;
        public DateTime Daten {get;set;}

        public Kurs()
        {
            
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

        public class DailyPrice
        {
            public string Date { get; set; }
            public decimal Price { get; set; }
        }

        public class Properties
        {
            public List<DailyPrice> DailyPrices { get; set; }
        }

        //dazu da das format der json datei zu bestimmen und auf die Daten aus der Api und der json datei zugreifen zu können

        public override string ToString()
        {
            return $"Werte: {werte}, Datum: {daten}";
        }
    }
}