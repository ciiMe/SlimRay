
using SlimRay.UserData;

namespace SlimRay.Designer.DataDefinition
{
    public interface ILog  
    {
        IField CreateDate { get; }

        IField UserID { get; }
        IField UserAccount { get; }
        IField TargetID { get; }
        IField TargetName { get; }
        IField Operation { get; }
    }
}
