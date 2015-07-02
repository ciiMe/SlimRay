
namespace SlimRay.UserData.Mapping
{
    public interface IMappedUserField : IUserField
    {
        DataMapPointer Source { get; set; }
    }
}
