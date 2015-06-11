using SlimRay.DB;

namespace SlimRay.UserData.Adapter
{
    public struct  UserDataStorage
    {
        IUserData Data { get; set; }
        DBAddress Address { get; set; }
    }
}
