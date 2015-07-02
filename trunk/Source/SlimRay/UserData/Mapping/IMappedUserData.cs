
namespace SlimRay.UserData.Mapping
{
    public interface IMappedUserData : IUserData
    {
        IMappedUserField[] Mapping { get; set; }
    }
}
