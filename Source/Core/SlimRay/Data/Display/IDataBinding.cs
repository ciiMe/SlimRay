
namespace SlimRay.Data.Display
{
    /// <summary>
    /// An object that bind to data source,
    /// to provide data.
    /// </summary>
    public interface IDataBinding
    {
        ISimpleData Data { get; set; }
        ISimpleField Field { get; set; }

        string GetValue(string format);

        /// <summary>
        /// Check the data.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        ProcessResult Check(string data);
    }
}
