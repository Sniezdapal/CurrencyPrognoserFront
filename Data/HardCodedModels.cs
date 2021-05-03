using System.Collections.Generic;

public class HardCodedModels : IModelProvider
{
    public IEnumerable<string> GetModels()
    {
        return new string[] { "ARIMA", "TOWER OF GOD", "BATHOMET" };
    }
}