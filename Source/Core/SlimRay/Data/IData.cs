
namespace SlimRay.Data
{
    /*
     * the simple data defines a data-object,
     * but it does not contain any data for the data-object you defined.
     */
    public interface IData
    {
        string Name { get; set; }
        string Description { get; set; }

        IField[] Fields { get; }

        void AddField(IField field);
        void RemoveFiled(int index);
    }
}
