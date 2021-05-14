using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

public class ConfigurationProvider : ICurrencyProvider, IModelProvider
{
    public ServerConf Conf { get; private set; }
    string _serverUrl;
    HttpClient _client;
    public ConfigurationProvider(IConfiguration conf, HttpClient client)
    {
        _serverUrl = conf["ServerURL"];
        _client = client;

    }
    public async Task<IEnumerable<string>> GetCurrencies()
    {
        var response = await _client.GetAsync($"{_serverUrl}/configuration");
        var body = await response.Content.ReadAsStringAsync();
        // var body = "{'models': ['autoregressive', 'regressive', 'exponential'], 'currencies': ['USD', 'EUR']}";
        Conf = JsonConvert.DeserializeObject<ServerConf>(body);
        return Conf.Currencies;
    }

    public async Task<IEnumerable<string>> GetModels()
    {
        var response = await _client.GetAsync($"{_serverUrl}/configuration");
        var body = await response.Content.ReadAsStringAsync();
        // var body = "{'models': ['autoregressive', 'regressive', 'exponential'], 'currencies': ['USD', 'EUR']}";
        Conf = JsonConvert.DeserializeObject<ServerConf>(body);
        return Conf.Models;
    }
}

public class ServerConf
{
    [JsonProperty("models")]
    public IEnumerable<string> Models { get; set; }
    [JsonProperty("currencies")]
    public IEnumerable<string> Currencies { get; set; }
}