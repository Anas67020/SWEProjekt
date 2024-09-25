using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;

public class MetaData
{
    [JsonProperty("1. Information")]
    public string Information { get; set; }

    [JsonProperty("2. Symbol")]
    public string Symbol { get; set; }

    [JsonProperty("3. Last Refreshed")]
    public DateTime LastRefreshed { get; set; }

    [JsonProperty("4. Output Size")]
    public string OutputSize { get; set; }

    [JsonProperty("5. Time Zone")]
    public string TimeZone { get; set; }
}

public class DailyData
{
    [JsonProperty("1. open")]
    public string Open { get; set; }

    [JsonProperty("2. high")]
    public string High { get; set; }

    [JsonProperty("3. low")]
    public string Low { get; set; }

    [JsonProperty("4. close")]
    public string Close { get; set; }

    [JsonProperty("5. volume")]
    public string Volume { get; set; }
}

public class TimeSeriesDaily
{
    [JsonProperty("Time Series (Daily)")]
    public Dictionary<string, DailyData> DailyTimeSeries { get; set; }
}

public class StockData
{
    [JsonProperty("Meta Data")]
    public MetaData MetaData { get; set; }

    [JsonProperty("Time Series (Daily)")]
    public Dictionary<string, DailyData> TimeSeriesDaily { get; set; }
}

public class Kurs
{
    public List<string> DailyPrices { get; private set; } = new List<string>();
    public List<double> Werte { get; private set; } = new List<double>();

    public Kurs()
    {
    }

    // Fetch stock data from API and parse it
    public async Task FetchStockDataAsync(string symbol = "IBM", string apiKey = "your_real_api_key")
    {
        try
        {
            using (var client = new HttpClient())
            {
                string apiUrl = "https://www.alphavantage.co/query?function=TIME_SERIES_DAILY&symbol=BA524MTAQU768D6W";

                // Send request
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();

                // Read the response as JSON
                string jsonResponse = await response.Content.ReadAsStringAsync();

                // Deserialize JSON into StockData object
                StockData stockData = JsonConvert.DeserializeObject<StockData>(jsonResponse);

                if (stockData != null && stockData.TimeSeriesDaily != null)
                {
                    // Clear previous data
                    DailyPrices.Clear();
                    Werte.Clear();

                    // Parse the daily data
                    foreach (var daily in stockData.TimeSeriesDaily)
                    {
                        DailyPrices.Add(daily.Key);  // Store the date
                        Werte.Add(double.Parse(daily.Value.Close));  // Store the closing price as a double
                    }
                }
                else
                {
                    Console.WriteLine("No data available or deserialization failed.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching data: {ex.Message}");
        }
    }
}
