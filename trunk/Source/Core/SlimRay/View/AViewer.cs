using SlimRay.View.Binding;

namespace SlimRay.View
{
    public class AViewer : IViewer
    {
        private UIBehaviorType _viewType;

        public UIBehaviorType ViewType
        {
            get { return _viewType; }
            set { _viewType = value; }
        }

        public AViewer(UIBehaviorType method)
        {
            _viewType = method;
        }
    }
}
