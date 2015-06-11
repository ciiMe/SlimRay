
namespace SlimRay.DB
{
    public struct DBAddress
    {
        /* 
         * the key of executor which will handle the request.
         * it should be the value of IExecutorCreator.GetKey().
         */
        public string Key { get; set; }

        /*
         * the address where the command execute at.
         * this is a virtual address, it can be any type of address such as
         * db server
         * ip address
         * file name
         * etc...
         */
        public string HostAddress { get; set; }
    }
}
