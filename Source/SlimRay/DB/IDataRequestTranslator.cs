using SlimRay.Data;

namespace DBHelpers.MSSQL
{
    /* Data command translator will do request command translation.
     * The command sent to SlimRay.Data is not a real db sql command, 
     * it should be translated to sql command or another language.
     */
    public interface IDataRequestTranslator
    {
        string ToDBCommand(DataRequest request);
    }
}
