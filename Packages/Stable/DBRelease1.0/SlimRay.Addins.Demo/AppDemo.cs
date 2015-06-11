using SlimRay.App;

namespace SlimRay.Addins.Demo
{
    public class AppDemo : IAddinApp
    {
        private const string _name = "demo addin";
        private const string _description = "an addin with demo function";
        private const string _key = "_external_Addin_demo__";

        public void Execute(string parameter)
        {
        }

        public string GetName()
        {
            return _name;
        }

        public string GetDescription()
        {
            return _description;
        }

        public string GetKey()
        {
            return _key;
        }
    }
}
