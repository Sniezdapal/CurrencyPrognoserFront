using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

public class ConfigurationProvider
{
    public ServerConf Conf { get; private set; }
    string _serverUrl;
    HttpClient _client;
    public ConfigurationProvider(IConfiguration conf, HttpClient client)
    {
        _serverUrl = conf["ServerURL"];
        _client = client;

    }
    public async Task InitAsync()
    {
        var response = await _client.GetAsync($"{_serverUrl}/configuration");
        var body = await response.Content.ReadAsStringAsync();
        // var body = "{'models': ['autoregressive', 'regressive', 'exponential'], 'currencies': ['USD', 'EUR']}";
        Conf = JsonConvert.DeserializeObject<ServerConf>(body);
    }
    public IEnumerable<string> GetCurrencies()
    {
        return Conf.Currencies;
    }

    public IEnumerable<string> GetModels()
    {
        return Conf.Models;
    }

    public IEnumerable<string> GetStocks() => Conf.Stocks;
}

public class ServerConf
{
    [JsonProperty("models")]
    public IEnumerable<string> Models { get; set; }
    [JsonProperty("currencies")]
    public IEnumerable<string> Currencies { get; set; }
    [JsonProperty("stocks")]
    public IEnumerable<string> Stocks { get; set; }
}