using SlimRay.Error;
using System;

namespace SlimRay.Action
{
    public class ActionStepEntity : IActionStep
    {
        protected string _name;
        protected string _description;

        protected ActionStatus _status;
        protected IActionStep _previousStep;
        protected IActionStep _nextStepOnSuccess;
        protected IActionStep _nextStepOnFail;
        protected ActionStepReturnMethod _returnMethod;

        protected ErrorEntiry _error;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public ActionStatus Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public IActionStep PreviousStep
        {
            get { return _previousStep; }
            set { _previousStep = value; }
        }

        public IActionStep NextStepOnSuccess
        {
            get { return _nextStepOnSuccess; }
            set { _nextStepOnSuccess = value; }
        }

        public IActionStep NextStepOnFail
        {
            get { return _nextStepOnFail; }
            set { _nextStepOnFail = value; }
        }

        public ActionStepReturnMethod ReturnMethod
        {
            get { return _returnMethod; }
            set { _returnMethod = value; }
        }

        public ErrorEntiry Error
        {
            get { return _error; }
            set { _error = value; }
        }

        public ActionStepEntity()
        {
        }

        public virtual bool Execute()
        {
            return true;
        }
    }
}
