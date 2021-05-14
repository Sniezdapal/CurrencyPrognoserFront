using System.Collections.Generic;
using System.Threading.Tasks;

public interface IModelProvider
{
    public Task<IEnumerable<string>> GetModels();
}