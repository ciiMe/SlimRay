using SlimRay.UserData;
using SlimRay.Action;
using SlimRay.View.Binding;

namespace SlimRay.View.Binding
{
    public class BindingShapeEntiry : IBindingShape
    {
        private IUserField _field;

        private UIBehaviorType _uiType;

        private string _text;
        private string _inputTitle;
        private string _tip;

        private IAction _action;

        private UIShape _shape;
        private double _x;
        private double _y;
        private double _height;
        private double _width;

        private IBindingShape[] _items;

        public IUserField DataField
        {
            get { return _field; }
            set { _field = value; }
        }

        public UIBehaviorType UIType
        {
            get { return _uiType; }
            set { _uiType = value; }
        }

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public string InputTitle
        {
            get { return _inputTitle; }
            set { _inputTitle = value; }
        }

        public string Tip
        {
            get { return _tip; }
            set { _tip = value; }
        }

        public IAction Action
        {
            get { return _action; }
            set { _action = value; }
        }

        public UIShape Shape
        {
            get { return _shape; }
            set { _shape = value; }
        }

        public double X
        {
            get { return _x; }
            set { _x = value; }
        }

        public double Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public double Height
        {
            get { return _height; }
            set { _height = value; }
        }

        public double Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public IBindingShape[] Items
        {
            get { return _items; }
            set { _items = value; }
        }
    }
}
