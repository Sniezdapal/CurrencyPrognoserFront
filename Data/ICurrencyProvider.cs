using System.Collections.Generic;

public interface ICurrencyProvider
{
    public IEnumerable<string> GetCurrencies();
}