using System.Collections.Generic;
using System.Threading.Tasks;

public class HardCodedCurrencies : ICurrencyProvider
{
    public async Task<IEnumerable<string>> GetCurrencies()
    {
        return await Task.FromResult(new List<string> {"USD", "EUR"});
    }
}