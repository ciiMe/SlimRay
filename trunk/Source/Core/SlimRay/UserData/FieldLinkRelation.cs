
namespace SlimRay.UserData
{
    /// <summary>
    /// The relationship between field and data.
    /// </summary>
    public enum FieldLinkRelation
    {
        /// <summary>
        /// The data that this field belongs to is detail records of field.
        /// a data of single record can link to its detail records.
        /// </summary>
        DetailData,

        /// <summary>
        /// the data that this field belongs to is another part of the whole data.
        /// any part of data can link to another.
        /// </summary>
        AnotherPartofData,

        /// <summary>
        /// the data that this field belongs to is a field of another data.
        /// a data should link to its list-type-field data.
        /// </summary>
        FieldofList,

        /// <summary>
        /// the data that this field belongs to is the data source, 
        /// in editor mode, all data should be choosed from data source.
        /// </summary>
        DataSource
    }
}
