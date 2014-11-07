
namespace SlimRay.Data
{
    /*
     * the simple data defines a data-object,
     * but it does not contain any data for the data-object you defined.
     */
    public interface ISimpleData
    {
        string Name { get; set; }
        string Description { get; set; }

        ISimpleField[] Fields { get; }

        void AddField(ISimpleField field);
        void RemoveFiled(int index);
    }
}
