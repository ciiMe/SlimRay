
namespace SlimRay.View
{
    public class AViewer : IViewer
    {
        private UIType _viewType;

        public UIType ViewType
        {
            get { return _viewType; }
            set { _viewType = value; }
        }

        public AViewer(UIType method)
        {
            _viewType = method;
        }
    }
}
