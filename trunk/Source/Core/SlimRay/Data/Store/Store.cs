using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SlimRay.Data.Store
{
    /*
     * The store provides data I/O service, and manages the IStoreProviders.
     * Store does not read or write any storage midea, the IStoreProvider does it.
     * As a role of management to IStoreProvider, store keep a map list between data and Provider,
     * so user does not care where data is saved, just call get(...) when they want to read data.
     */
    public class Store
    {
        private IStoreProvider _provider;
    }
}
