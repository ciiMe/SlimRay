
namespace SlimRay.Data.Display
{
    public interface BindingAdapter
    {
        string FormatString { get; set; }

        string GetFieldValue();

    }
}
