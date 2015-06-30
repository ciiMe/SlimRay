using SlimRay.App;

namespace SlimRay.Addins.Demo
{
    public class AppDemo : BaseApp
    {
        public AppDemo()
        {
            _name = "demo addin";
            _description = "an addin with demo function";
            _key = "_external_Addin_demo__";
            _version = "0.1";
        }
    }
}
