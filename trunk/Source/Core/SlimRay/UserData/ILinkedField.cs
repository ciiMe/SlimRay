
namespace SlimRay.UserData
{
    public struct ILinkedField
    {
        IField Field { get; set; }
        FieldLinkRelation Relation { get; set; }
    }
}
