using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SlimRay.Common
{
    public struct Action
    {
        string Name { get; set; }
    }

    public struct ActionResult
    {
        bool Success { get; set; }
        string Message { get; set; }
    }
}
