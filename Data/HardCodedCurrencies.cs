using System.Collections.Generic;

public class HardCodedCurrencies : ICurrencyProvider
{
    public IEnumerable<string> GetCurrencies()
    {
        return new List<string> {"USD", "EUR"};
    }
}