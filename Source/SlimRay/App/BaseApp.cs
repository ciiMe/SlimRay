using SlimRay.Utils;

namespace SlimRay.App
{
    public abstract class BaseApp : IAPP
    {
        protected string _name;
        protected string _version;
        protected string _description;
        protected string _key;
        protected AddinDependence[] _dependentApps;

        protected bool _isInitialized;

        public BaseApp()
        {
            _name = "Base App.";
            _version = "15.06.30";
            _description = "";
            _key = "";
            _dependentApps = new AddinDependence[] { };
        }

        public string GetName()
        {
            return _name;
        }

        public string GetVersion()
        {
            return _version;
        }

        public bool IsVersionHigherThan(string previousVersion)
        {
            VersionHelper vh = new VersionHelper();
            return vh.IsABigger(_version, previousVersion, '.');
        }

        public string GetDescription()
        {
            return _description;
        }

        public string GetKey()
        {
            return _key;
        }

        public bool IsInitialized()
        {
            return _isInitialized;
        }

        public AddinDependence[] GetDependencies()
        {
            return _dependentApps;
        }

        public virtual void Initialize(string parameter)
        {
            _isInitialized = true;
        }

        public virtual void Terminate()
        {

        }
    }
}
