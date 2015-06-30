
namespace SlimRay.App
{
    public interface IAddinDependenceHelper
    {
        /// <summary>
        /// find all dependence and order them, 
        /// then you can register the apps by the same order with apps in result data.
        /// </summary>
        IAPP[] GetRegisterableApps(IAPP app);

        IAPP[] GetRegisterableApps(IAPP[] apps);
    }
}
