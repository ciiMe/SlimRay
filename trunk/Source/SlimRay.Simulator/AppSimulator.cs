using SlimRay.App;
using SlimRay.Addins.Simulator.Apps;

namespace SlimRay.Addins.Simulator
{
    public class AppSimulator : IAddinApp
    {
        private const string _name = "SlimRay simulator";
        private const string _description = "Set up a virtual environment to load data.";
        private const string _key = "_SlimRay_Addin_Simulator";

        /// <summary>
        /// install all system apps, config SlimRay by simulate apps 
        /// which do not really load real data but also return data with same format.
        /// </summary>
        public static void Initialize()
        {
            ISimulatorApp app;

            app = new UserDataLoader();
            AppGate.RegisterSimulatorApp(app);

            app = new BindingConfigLoader();
            AppGate.RegisterSimulatorApp(app);
        }

        public void Execute(string parameter)
        {
            Initialize();
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
