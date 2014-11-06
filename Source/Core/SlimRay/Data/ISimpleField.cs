
namespace SlimRay.Data
{
    public interface ISimpleField
    {
        /// <summary>
        /// The data that this filed belongs to.
        /// </summary>
        ISimpleData Data { get; set; }

        DataTypes Type { get; set; }

        string Name { get; set; }
        string Description { get; set; }

        string Value { get; set; }

        void Link(ISimpleData data, FieldLinkRelation relation);
    }
}
