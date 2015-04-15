
namespace SlimRay.UserData
{
    /*
     * the simple data defines a data-object,
     * but it does not contain any data for the data-object you defined.
     */
    public interface IData
    {
        int ID { get; set; }
        string Name { get; set; }
        string Description { get; set; }

        IField[] Fields { get; }
        ILinkedField[] LinkedFields { get; }

        void AddField(IField field);
        void RemoveFiled(int index);

        void Link(IField field, FieldLinkRelation relation);
        void UnLink(string fieldName);
        void UnLink(int index);
    }
}
