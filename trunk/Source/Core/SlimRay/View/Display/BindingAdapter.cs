
namespace SlimRay.View.Display
{
    public interface BindingAdapter
    {
        string FormatString { get; set; }

        string GetFieldValue();

    }
}
