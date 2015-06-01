using System.Windows.Forms;

namespace SlimRay.View.Binding.Components
{
    public abstract class ABaseDisplayUI :  BoundShapeEntiry, IUI,IDisplayUIBehavior, IUIBehavior
    {
        private Control _canvas;
        private IUI _parent;

        public Control Canvas
        {
            get { return _canvas; }
            set { _canvas = value; }
        }

        public IUI Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }

        public abstract void Bind(UserData.IUserData data);
        public abstract void Load();
        public abstract void Refresh();

        public abstract void Show();
        public abstract void Hide();
        public abstract void Close();
    }
}
