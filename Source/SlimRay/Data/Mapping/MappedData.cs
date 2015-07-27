using SlimRay.UserData;

namespace SlimRay.Data.Mapping
{
    public struct MappedData
    {
        IUserData Surface { get; set; }
        DataEntity Entity { get; set; }
    }
}
