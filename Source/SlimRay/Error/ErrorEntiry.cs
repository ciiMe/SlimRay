
namespace SlimRay.Error
{
    public struct ErrorEntiry
    {
        /// <summary>
        /// domain id for this error, such as user management, data management etc.
        /// </summary>
        public int DomainId { get; set; }

        /// <summary>
        /// unquie id for this kind of error.
        /// </summary>
        public int ErrorCode { get; set; }

        /// <summary>
        /// detail message about this error.
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// the text help to fix this error.
        /// </summary>
        public string FixTip { get; set; }
    }
}
