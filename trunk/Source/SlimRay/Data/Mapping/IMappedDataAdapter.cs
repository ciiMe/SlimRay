
namespace SlimRay.Data.Mapping
{
    public interface IMappedDataAdapter
    {
        string GetDataName(string surfaceName);
        string GetFieldName(string surfaceName);
    }
}
