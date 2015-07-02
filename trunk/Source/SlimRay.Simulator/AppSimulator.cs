using SlimRay.App;
using SlimRay.Addins.Simulator.Apps;

namespace SlimRay.Addins.Simulator
{
    public class AppSimulator : BaseApp
    {
        public AppSimulator()
        {
            _name = "SlimRay simulator";
            _description = "Set up a virtual environment to load data.";
            _key = "_SlimRay_Addin_Simulator";

            _version = "1.0.0";
        }

        /// <summary>
        /// install all system apps, config SlimRay by simulate apps 
        /// which do not really load real data but also return data with same format.
        /// </summary>
        public override void Initialize(string parameter)
        {
            ISimulatorApp app;

            app = new UserDataHelper();
            AppGate.Instance.RegisterSimulatorApp(app);

            app = new BindingConfigLoader();
            AppGate.Instance.RegisterSimulatorApp(app);

            _isInitialized = true;
        }

        public override void Terminate()
        {
        }
    }
}
