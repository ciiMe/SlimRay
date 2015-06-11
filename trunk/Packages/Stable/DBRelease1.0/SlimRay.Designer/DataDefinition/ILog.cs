
using SlimRay.UserData;

namespace SlimRay.Designer.DataDefinition
{
    public interface ILog  
    {
        IUserField CreateDate { get; }

        IUserField UserID { get; }
        IUserField UserAccount { get; }
        IUserField TargetID { get; }
        IUserField TargetName { get; }
        IUserField Operation { get; }
    }
}
