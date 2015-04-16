
using SlimRay.UserData;

namespace SlimRay.Designer.DataDefinition
{
    public interface IUser
    {
        IField ID { get; }

        IField CreateDate { get; }
        IField CreateUserID { get; }
        IField CreateUserAccount { get; }

        IField Status { get; }

        IField LoginAccount { get; }
        IField LoginPassword { get; }

        IField LastLoginDate { get; }
    }

    public interface IUserLoginLog : ILog
    {
        IField LoginIp { get; }
    }
}
