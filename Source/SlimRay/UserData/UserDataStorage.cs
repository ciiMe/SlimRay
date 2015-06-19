using SlimRay.DB;

namespace SlimRay.UserData
{
    public struct  UserDataStorage
    {
        IUserData Data { get; set; }
        DBAddress Address { get; set; }
    }
}
