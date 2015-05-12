using SlimRay.UserData;
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
    public enum UIBehaviorType
    {
        AsForm,

        AsReadonlyText,
        AsEditableText,

        AsDropdownList,
        AsSelectOnlyDropDownList,

        AsRadio,
        AsCheckable,

        AsCanlendar,

        AsGrid,

        AsButton
    }

    /// <summary>
    /// a shape is a container,
    /// holds many items within its shape.
    /// a child item is a component, 
    /// it binds only one record of data and show it.
    /// </summary>
    public interface IBindingShape
    {
        /// <summary>
        /// the data will be shown on UI.
        /// </summary>
        IUserField DataField { get; set; }

        /// <summary>
        /// this setting decides the kind of UI it acts.
        /// </summary>
        UIBehaviorType UIType { get; set; }

        /// <summary>
        /// the text shows on top of the ui,
        /// a form or a container always need a title.
        /// </summary>
        string Text { get; set; }

        /// <summary>
        /// a input ui should have input title,
        /// the input title shows in front of input area.
        /// </summary>
        string InputTitle { get; set; }

        /// <summary>
        /// the tip when mouse hover.
        /// </summary>
        string Tip { get; set; }

        //todo: action is here, but when should it be called?
        IAction Action { get; set; }

        UIShape Shape { get; set; }

        double X { get; set; }
        double Y { get; set; }
        double Height { get; set; }
        double Width { get; set; }

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
