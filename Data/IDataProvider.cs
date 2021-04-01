using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

public interface IDataProvider
{
    public Task<Dictionary<string, Dictionary<string, double>>> GetData(DateTime timeFrom, DateTime timeTo, IEnumerable<string> currencies);
}