
using System.Collections.Generic;
namespace SlimRay.Data
{
    public class DataFilterItem
    {
        public string fieldName { get; set; }
        public string value { get; set; }
    }

    public class DataFilter : List<DataFilterItem>
    { }
}
