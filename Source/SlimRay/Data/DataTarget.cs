
namespace SlimRay.Data
{
    /// <summary>
    /// what target will the action effect to.
    /// </summary>
    public enum DataTarget
    {
        /// <summary>
        /// the action will change the struct of data, such as add field, remove field.
        /// </summary>
        Data,

        /// <summary>
        /// the action will chage the property of field, such as field size, field name, field max length etc.
        /// </summary>
        Field,

        /// <summary>
        /// the action will change the value of field.
        /// </summary>
        FieldValue
    }
}
