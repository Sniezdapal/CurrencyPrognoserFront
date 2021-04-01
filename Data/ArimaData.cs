using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class ArimaData : IDataProvider
{
    HttpClient _client { get; set; }
    public ArimaData(HttpClient client)
    {
        _client = client;
    }

    public async Task<Dictionary<string, Dictionary<string, double>>> GetData(DateTime timeFrom, DateTime timeTo, IEnumerable<string> currencies)
    {
        var json = new Request()
        {
            begin = timeFrom.ToTimestamp().ToString(),
            end = timeTo.ToTimestamp().ToString(),
            currency_names = currencies.ToArray()
        }.ToJson();
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _client.PostAsync("http://localhost:5000/get_currency", content);
        var tt = await response.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, double>>>(tt);
    }
}