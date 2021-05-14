using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Models;

public class RandomData : IDataProvider
{
    private HttpClient _client;
    private Random rand = new Random();

    public RandomData(HttpClient client)
    {
        _client = client;
    }
    public async Task<DataSet> GetData(DateTime timeFrom, DateTime timeTo, IEnumerable<string> currencies, string model)
    {
        var data = new DataSet();
        foreach (var currency in currencies)
        {
            for (var i = timeFrom; i < timeTo; i = i.AddDays(1))
            {
                var dataItem = new DataItem() {Date = i, CurrencyRate = 2.5 + rand.NextDouble() * 1};
                data[currency].Add(dataItem);
            }
        }
        await Task.Delay(500);
        return data;
    }

    public Task<DataSet> GetStockData(DateTime timeFrom, DateTime timeTo, IEnumerable<string> stocks, string model)
    {
        throw new NotImplementedException();
    }
}