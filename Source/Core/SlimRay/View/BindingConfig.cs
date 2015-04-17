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
    /// shape of UI component
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
    /// a shape that bind data,
    /// show data fields in this shape.
    /// </summary>
    public interface IBindingShape
    {
        double X { get; set; }
        double Y { get; set; }

        UIShape Shape { get; set; }

        double height { get; set; }
        double width { get; set; }

        BindingItem[] Items { get; set; }
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

    /// <summary>
    /// an item in binding shape
    /// </summary>
    public struct BindingItem
    {
        int index { get; set; }

        int DataID { get; set; }
        int FieldID { get; set; }

        /// <summary>
        /// shape to show this binding item.
        /// this config is used only when the binding shape works in DetailItems mode.
        /// </summary>
        UIShape Shape { get; set; }

        /// <summary>
        /// children components in this item.
        /// </summary>
        IBindingShape[] Children { get; set; }
    }


}
