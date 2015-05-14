using SlimRay.Error;
using SlimRay.View.Binding;

namespace SlimRay.Action
{
    public interface IActionStep
    {
        IBindingShape UI { get; set; }

        string Name { get; set; }
        string Description { get; set; }

        ActionStatus Status { get; set; }
        IActionStep PreviousStep { get; set; }
        IActionStep NextStepOnSuccess { get; set; }
        IActionStep NextStepOnFail { get; set; }

        ActionStepReturnMethod ReturnMethod { get; set; }

        ErrorEntiry Error { get; set; }

        bool Execute();
    }
}
