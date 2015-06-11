
namespace SlimRay.View.Binding
{
    public interface IEditUIBehavior : IDisplayUIBehavior
    {
        void Check();
        void Commit();
    }
}
