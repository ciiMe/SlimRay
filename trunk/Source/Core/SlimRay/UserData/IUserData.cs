
namespace SlimRay.UserData
{
    /*
     * the simple data defines a data-object,
     * but it does not contain any data for the data-object you defined.
     */
    public interface IUserData
    {
        /// <summary>
        /// internal ID for this type of data.
        /// </summary>
        int ID { get; set; }

        /// <summary>
        /// name of data, always use in UI, this is a name that shown to User, not name for code-developer.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// a short text, show what this data is, 
        /// the description may be shown in INPUT form, help user to input or select.
        /// </summary>
        string Description { get; set; }

        IUserField[] Fields { get; }
        LinkedUserField[] LinkedFields { get; }

        void AddField(IUserField field);
        void RemoveFiled(int index);

        void Link(IUserField field, UserFieldLinkRelation relation);
        void UnLink(string fieldName);
    }
}
