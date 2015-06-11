
using SlimRay.UserData;

namespace SlimRay.Designer.DataDefinition
{
    public interface IUser
    {
        IUserField ID { get; }

        IUserField CreateDate { get; }
        IUserField CreateUserID { get; }
        IUserField CreateUserAccount { get; }

        IUserField Status { get; }

        IUserField LoginAccount { get; }
        IUserField LoginPassword { get; }

        IUserField LastLoginDate { get; }
    }

    public interface IUserLoginLog : ILog
    {
        IUserField LoginIp { get; }
    }
}
