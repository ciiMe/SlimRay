using System.Drawing;

namespace SlimRay.View
{
    /// <summary>
    /// shape of UI component, it tells how to draw an UI.
    /// </summary>
    public struct UIEntity
    {
        Color ForeColor { get; set; }
        Color BackgroundColor { get; set; }

        double Angle { get; set; }

        ShapeBorder BorderStyle { get; set; }
    }
}