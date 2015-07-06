using System.Data;

namespace SlimRay.Data
{
    /* this app access the real data.
     * it's the real one to read and write data.
     */
    public interface IDataAccessApp
    {
        DataTable GetTable(DataRequest request);
        string GetValue(DataRequest request);

        bool Execute(DataRequest request);
    }
}
