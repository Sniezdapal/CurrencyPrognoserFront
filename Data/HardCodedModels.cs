using System.Collections.Generic;
using System.Threading.Tasks;

public class HardCodedModels : IModelProvider
{
    public async Task<IEnumerable<string>> GetModels()
    {
        return await Task.FromResult(new string[] { "ARIMA", "TOWER OF GOD", "BATHOMET" });
    }
}