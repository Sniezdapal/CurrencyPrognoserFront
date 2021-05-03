using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Models;

public interface IDataProvider
{
    public Task<List<DataSet>> GetData(DateTime timeFrom, DateTime timeTo, IEnumerable<string> currencies);
}