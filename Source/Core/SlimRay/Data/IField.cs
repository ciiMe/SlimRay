
namespace SlimRay.Data
{
    public interface IField
    {
        /// <summary>
        /// The data that this filed belongs to.
        /// </summary>
        IData Data { get; set; }

        FieldType Type { get; set; }

        string Name { get; set; }
        string Description { get; set; }

        void Link(IData data, FieldLinkRelation relation);
    }
}
