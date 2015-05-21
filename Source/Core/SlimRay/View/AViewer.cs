using SlimRay.View.Binding;

namespace SlimRay.View
{
    public class AViewer : IViewer
    {
        private UICategory _viewType;

        public UICategory ViewType
        {
            get { return _viewType; }
            set { _viewType = value; }
        }

        public AViewer(UICategory method)
        {
            _viewType = method;
        }
    }
}
