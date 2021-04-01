using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

public class RandomData : IDataProvider
{
    private HttpClient _client;
    private Random rand = new Random();

    public RandomData(HttpClient client)
    {
        _client = client;
    }
    public async Task<Dictionary<string, Dictionary<string, double>>> GetData(DateTime timeFrom, DateTime timeTo, IEnumerable<string> currencies)
    {
        Dictionary<string, Dictionary<string, double>> data = new Dictionary<string, Dictionary<string, double>>();
        foreach(var currency in currencies)
        {
            var values = new Dictionary<string, double>();
            for (var i = timeFrom; i < timeTo; i = i.AddDays(1))
            {
                values.Add(i.ToTimestamp().ToString(), rand.NextDouble() * 10);
            }
            data.Add(currency, values);
        }
        await Task.Delay(500);
        return data;
    }
}