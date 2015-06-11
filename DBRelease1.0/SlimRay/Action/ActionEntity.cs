using System;

namespace SlimRay.Action
{
    public class ActionEntity : ActionStepEntity, IAction
    {
        public IAction CurrentStep
        {
            get { throw new NotImplementedException(); }
        }

        public ActionEntity()
        {
            _returnMethod = ActionStepReturnMethod.ReturnOriginalResult;
        }

        public ActionError[] Errors
        {
            get { throw new NotImplementedException(); }
        }

        public bool ExecuteToEnd()
        {
            throw new NotImplementedException();
        }

        public bool ExecuteTo(IActionStep step)
        {
            throw new NotImplementedException();
        }

        public bool ExecuteTo(string stepName)
        {
            throw new NotImplementedException();
        }
    }
}
