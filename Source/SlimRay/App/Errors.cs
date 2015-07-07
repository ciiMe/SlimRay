using System;

namespace SlimRay.App
{
    public class NoAppRegisterExceptioin : Exception
    {
        public NoAppRegisterExceptioin(string message)
            : base(message)
        {

        }
    }
}
