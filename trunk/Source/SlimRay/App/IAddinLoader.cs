
namespace SlimRay.App
{
    internal interface IAddinLoader
    {
        IAddinApp Load(string filename);
        void Unload(IAddinApp app);
    }
}
