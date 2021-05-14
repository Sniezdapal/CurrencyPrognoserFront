using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Models;

namespace Data
{
    public class ServerData : IDataProvider
    {
        private HttpClient _client;
        private string _serverUrl;

        public ServerData(IConfiguration conf, HttpClient client)
        {
            _client = client;
            _serverUrl = conf["ServerURL"];
        }
        public async Task<DataSet> GetData(DateTime timeFrom, DateTime timeTo, IEnumerable<string> currencies, string model)
        {
            var body = new
            {
                begin = timeFrom.ToTimestamp(),
                end = timeTo.ToTimestamp(),
                currency_names = currencies,
                model = model
            };
            var response = await _client.PostAsJsonAsync($"{_serverUrl}/get_currency", body);
            var responseObject = await response.Content.ReadAsAsync<Dictionary<string, Dictionary<string, double>>>();
            var datas = new DataSet();
            foreach(var currency in responseObject.Keys)
            {
                var rateList = new List<DataItem>();
                foreach(var rates in responseObject[currency])
                {
                    rateList.Add(new DataItem { Date = rates.Key.FromTimestamp(), CurrencyRate = rates.Value });
                }
                datas[currency] = rateList;
            }
            return datas;
        }
    }
}