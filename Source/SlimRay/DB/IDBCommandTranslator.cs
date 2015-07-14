
namespace SlimRay.DB
{
    /// <summary>
    /// The command text of a DB language may be different from another, 
    /// so this DBCommandTranslator will translate the genernal DB command to the real DB language.
    /// </summary>
    public interface IDBCommandTranslator
    {
        string ToDBCommand(DBRequest request);
    }
}
