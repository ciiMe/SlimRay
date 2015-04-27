
namespace SlimRay.View
{
    public class AViewer : IViewer
    {
        private FieldDisplayMethod _viewType;

        public FieldDisplayMethod ViewType
        {
            get { return _viewType; }
            set { _viewType = value; }
        }

        public AViewer(FieldDisplayMethod method)
        {
            _viewType = method;
        }
    }
}
