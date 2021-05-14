using System.Collections.Generic;
using System.Threading.Tasks;

public interface ICurrencyProvider
{
    public Task<IEnumerable<string>> GetCurrencies();
}