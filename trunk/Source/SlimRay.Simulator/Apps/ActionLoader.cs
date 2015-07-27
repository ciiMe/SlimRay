using SlimRay.Action;
using SlimRay.App.Loaders;
using SlimRay.App;
using System.Collections.Generic;

namespace SlimRay.Addins.Simulator.Apps
{
    public class ActionLoader : BaseApp, ISimulatorApp, IActionLoader
    {
        private List<IAction> _actions;

        public ActionLoader()
        {
            _name = "Action Loader.";
            _description = "Load all actions.";
            _version = "0.1";

            _key = AppKeys.ActionLoader;

            _actions = new List<IAction>();
            initActions();
        }

        public override void Initialize(string parameter)
        {
            _isInitialized = true;
        }

        public override void Terminate()
        {
            throw new System.NotImplementedException();
        }

        private void initActions()
        {
            IAction actn;

            actn = new ActionEntity
            {
                Name = "Submit form data.",
                Description = "submit all input data within the form.",

                ReturnMethod = ActionStepReturnMethod.ReturnOriginalResult
            };
            _actions.Add(actn);
        }

        public IAction[] Get()
        {
            return _actions.ToArray();
        }
    }
}
