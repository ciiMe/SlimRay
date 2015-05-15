using System;
using SlimRay.Action;
using SlimRay.App.Loaders;
using SlimRay.App;
using System.Collections.Generic;

namespace SlimRay.Simulator.Apps
{
    public class ActionLoader : ISimulatorApp, IActionLoader
    {
        private const string _name = "Action Loader.";

        private List<IAction> _actions;

        public string Name
        {
            get { return _name; }
        }

        public string SerialKey
        {
            get { return AppKeys.ActionLoader; }
        }

        public ActionLoader()
        {
            _actions = new List<IAction>();

            initActions();
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
