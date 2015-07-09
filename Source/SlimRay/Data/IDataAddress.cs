using System;

namespace SlimRay.Data
{
    public interface IDataAddress
    {
        string DataKey { get; set; }
        string Address { get; set; }
    }
}
