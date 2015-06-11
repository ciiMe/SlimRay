
namespace SlimRay.View.Binding.Components
{
    public abstract class ABaseDisplayUI :  BoundShapeEntiry, IUI,IDisplayUIBehavior, IUIBehavior
    {
        private IUI _parent;
        
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
