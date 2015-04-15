
namespace SlimRay.View.Display
{
    /// <summary>
    /// An object that bind to the component,
    /// to display values and get input values.
    /// </summary>
    public interface IComponentBinding
    {
        /// <summary>
        /// Format string,define the format that data is shown.
        /// </summary>
        string DisplayFormat { get; set; }

        /// <summary>
        /// Trim input value before save.
        /// </summary>
        bool TrimBeforeSave { get; set; }

        string GetInputValue();
    }
}
