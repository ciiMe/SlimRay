using System.Windows.Forms;

namespace SlimRay.View
{
    public interface IUI
    {
        IUI Parent { get; set; }
        Control Canvas { get; set; }
    }
}
