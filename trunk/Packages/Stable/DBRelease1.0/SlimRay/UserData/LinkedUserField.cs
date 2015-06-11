
namespace SlimRay.UserData
{
    public struct LinkedUserField
    {
        public IUserField Field { get; set; }
        public UserFieldLinkRelation Relation { get; set; }
    }
}
