
namespace SlimRay.Action
{
    public interface IAction : IActionStep
    {
        IAction CurrentStep { get; }

        /// <summary>
        /// all errors while executing action steps.
        /// </summary>
        ActionError[] Errors { get; }

        bool ExecuteToEnd();
        bool ExecuteTo(IActionStep step);
        bool ExecuteTo(string stepName);
    }
}
