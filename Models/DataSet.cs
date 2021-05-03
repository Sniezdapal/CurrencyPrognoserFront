using System.Collections.Generic;

namespace Models
{
    public struct DataSet
    {
        public List<DataItem> Items { get; set; }
        public string CurrencyName { get; set; }
    }
}