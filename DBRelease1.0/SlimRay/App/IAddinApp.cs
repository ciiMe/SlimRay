
namespace SlimRay.App
{
    /* an addin app is written by other users, 
     * the addin stores in \addins\xxx.dll
     * 
     */
    public interface IAddinApp : IApp
    {
        void Execute(string parameter);
    }
}
