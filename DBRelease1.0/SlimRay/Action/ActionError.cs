using SlimRay.Error;
using System.Collections.Generic;

namespace SlimRay.Action
{
    public struct ActionError
    {
        IAction Action { get; set; }
        ErrorEntiry Error { get; set; }
    }
}
