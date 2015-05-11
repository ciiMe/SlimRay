using System.Drawing;

namespace SlimRay.View
{
    /// <summary>
    /// for the first versions,
    /// we only support rectangle shape,
    /// in feature,
    /// </summary>
    public enum BindShapeType
    {
        Rectangle
    }

    public enum LineStyle
    {
        None,
        Solid,
        Dash,
        Dot,
        DashDot
    }

    public struct ShapeBorder
    {
        LineStyle Style { get; set; }
        double Width { get; set; }
        Color ForeColor { get; set; }
    }

    /// <summary>
    /// shape of UI component, it tells how to draw an UI.
    /// </summary>
    public struct UIShape
    {
        BindShapeType Type { get; set; }

        Color ForeColor { get; set; }
        Color BackgroundColor { get; set; }

        double Angle { get; set; }

        ShapeBorder BorderStyle { get; set; }

        //todo: there will be many advance features in shape, 
        //we'll do it in future.
    }

    /// <summary>
    /// the common type of a UI.
    /// </summary>
    public enum UIType
    {
        AsText,

        AsDropdownList,
        AsSelectOnlyDropDownList,

        AsRadio,
        AsCheckable,

        AsCanlendar,

        AsGrid
    }

    /// <summary>
    /// a shape is a container,
    /// holds many items within its shape.
    /// a child item is a component, 
    /// it binds only one record of data and show it.
    /// </summary>
    public interface IBindingShape
    {
        int DataID { get; set; }
        int FieldID { get; set; }

        UIType Type { get; set; }

        UIShape Shape { get; set; }

        double X { get; set; }
        double Y { get; set; }
        double height { get; set; }
        double width { get; set; }

        IBindingShape[] Items { get; set; }
    }

    /// <summary>
    /// how to show items in this shape.
    /// </summary>
    public enum BindingShapeType
    {
        DetailItems,
        GridView,
        ListView
    }
}
