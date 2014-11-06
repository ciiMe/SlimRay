
namespace SlimRay.Data
{
    public interface ISimpleData
    {
        string Name { get; set; }
        string Description { get; set; }

        ISimpleField[] Fields { get; }

        void AddField(ISimpleField field);
        void RemoveFiled(int index);
    }
}
