
namespace SlimRay.View
{
    /// <summary>
    /// Each view can display data in one method, 
    /// the viewer can be registered to system, 
    /// ViewType is the key property to a viewer, it tells system how this view show data.
    /// any viewer should be able to be replaced by another viewer with same viewType.
    /// </summary>
    public interface IViewer
    {
        FieldDisplayMethod ViewType { get; set; }
    }
}
