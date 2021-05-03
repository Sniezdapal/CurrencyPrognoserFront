using System.Collections.Generic;

public interface IModelProvider
{
    public IEnumerable<string> GetModels();
}