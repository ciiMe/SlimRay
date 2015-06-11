
using SlimRay.UserData;

namespace SlimRay.Designer.DataDefinition
{
    public interface ISystemData : IUserData
    {
        IUserField CreateDate { get; }
        IUserField CreateUserID { get; }
        IUserField CreateUserAccount { get; }
    }

    public interface ISystemDataFIeld : IUserData
    {
        IUserField DataID { get; }

        IUserField Type { get; }
        IUserField MaxLength { get; }
        IUserField InputTip { get; }
        IUserField AllowNull { get; }
    }

    public interface ISystemDataLink
    {
        IUserField MainDataID { get; }
        IUserField MainFieldID { get; }
        IUserField Relation { get; }
        IUserField LinkedDataID { get; }
        IUserField LinkedFieldID { get; }
    }

    public interface ISystemDataLog : ILog
    {
        IUserField DataContentID { get; }
        IUserField RecoverID { get; }
    }

    public interface ISystemDataRecover
    {
        IUserField DataID { get; }
        IUserField DataContentID { get; }
        IUserField DataContent { get; }
    }
}
