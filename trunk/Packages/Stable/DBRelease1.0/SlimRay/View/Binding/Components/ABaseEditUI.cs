
namespace SlimRay.View.Binding.Components
{
    public abstract class ABaseEditUI : ABaseDisplayUI, IUI, IEditUIBehavior, IUIBehavior
    {
        public abstract void Check();
        public abstract void Commit();
    }
}
