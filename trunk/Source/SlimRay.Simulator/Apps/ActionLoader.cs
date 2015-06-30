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

            _actions = new List<IAction>();
            initActions();
        }

        public void Initialize(string parameter)
        {
            _isInitialized = true;
        }

        public void Terminate()
        {
            throw new System.NotImplementedException();
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
            return AppKeys.ActionLoader;
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
