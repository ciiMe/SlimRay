
namespace SlimRay.App
{
    internal interface IAddinLoader
    {
        IAPP[] Load(bool includeDependence);
        IAPP[] Load(string addinFileName, bool includeDependence);
    }
}
