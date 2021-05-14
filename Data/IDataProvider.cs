using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Models;

public interface IDataProvider
{
    public Task<DataSet> GetData(DateTime timeFrom, DateTime timeTo, IEnumerable<string> currencies, string model);
    public Task<DataSet> GetStockData(DateTime timeFrom, DateTime timeTo, IEnumerable<string> stocks, string model);
}