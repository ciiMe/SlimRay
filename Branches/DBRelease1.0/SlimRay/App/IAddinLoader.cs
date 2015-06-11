
namespace SlimRay.App
{
    internal interface IAddinLoader
    {
        IAddinApp[] LoadAll();
        IAddinApp[] Load(string addinFileName);
        void Unload(IAddinApp app);
    }
}
