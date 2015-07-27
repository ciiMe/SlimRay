using SlimRay.DB;

namespace SlimRay.Data.Mapping
{
    /* Data command translator will do request command translation.
     * The command sent to SlimRay.Data is not a real db sql command, 
     * it should be translated to sql command or another language.
     */
    public interface IDataRequestTranslator
    {
        DBRequest translate(DataRequest request);
    }
}
