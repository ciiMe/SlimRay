using SlimRay.App;
using SlimRay.Simulator.Apps;

namespace SlimRay.Simulator
{
    public class Application
    {
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
    }
}
