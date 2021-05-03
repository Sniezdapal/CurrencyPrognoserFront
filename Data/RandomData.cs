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
    public async Task<List<DataSet>> GetData(DateTime timeFrom, DateTime timeTo, IEnumerable<string> currencies)
    {
        var datas = new List<DataSet>();
        foreach (var currency in currencies)
        {
            var data = new DataSet() { CurrencyName = currency, Items = new List<DataItem>() };
            for (var i = timeFrom; i < timeTo; i = i.AddDays(1))
            {
                var dataItem = new DataItem() {Date = i, CurrencyRate = rand.NextDouble() * 10};
                data.Items.Add(dataItem);
            }
            datas.Add(data);
        }
        await Task.Delay(500);
        return datas;
    }
}