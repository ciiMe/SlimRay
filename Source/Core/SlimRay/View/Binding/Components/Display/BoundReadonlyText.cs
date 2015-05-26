using SlimRay.UserData;
using System.Windows.Forms;

namespace SlimRay.View.Binding.Components.Display
{
    public class BoundReadonlyText : ABaseDisplayUI
    {
        private Label _canvas;
        private IUserData _data;

        public BoundReadonlyText()
        {
            _canvas = new Label()
            {
                Parent = Parent.Canvas
            };
        }

        public override void Load()
        {
            _canvas.Text = DataAdapter.DataLoader.LoadUserDataValue(DataField);
        }

        public override void Refresh()
        {
            _canvas.Text = DataAdapter.DataLoader.LoadUserDataValue(DataField);
        }

        public override void Show()
        {
            _canvas.Visible = true;
        }

        public override void Hide()
        {
            _canvas.Visible = false;
        }

        public override void Close()
        {
            _canvas.Dispose();
        }

        public override void Bind(IUserData data)
        {
            _data = data;
        }
    }
}
