
namespace SlimRay.App
{
    public interface IAPP
    {
        string GetName();
        string GetVersion();
        string GetDescription();
        string GetKey();
        AddinDependence[] GetDependencies();

        bool IsInitialized();

        bool IsVersionHigherThan(string previousVersion);
        void Initialize(string parameter);
        void Terminate();
    }
}
