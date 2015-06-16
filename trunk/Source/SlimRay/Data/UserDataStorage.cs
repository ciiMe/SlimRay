using SlimRay.DB;
using SlimRay.UserData;

namespace SlimRay.Data
{
    public struct  UserDataStorage
    {
        IUserData Data { get; set; }
        DBAddress Address { get; set; }
    }
}
