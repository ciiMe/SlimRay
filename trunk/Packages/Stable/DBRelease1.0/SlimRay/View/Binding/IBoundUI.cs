using SlimRay.Action;
using SlimRay.UserData;

namespace SlimRay.View.Binding
{
    /// <summary>
    /// a shape is a container,
    /// holds many items within its shape.
    /// a child item is a component, 
    /// it binds only one record of data and show it.
    /// </summary>
    public interface IBoundUI
    {
        /// <summary>
        /// the data will be shown on UI.
        /// </summary>
        IUserField DataField { get; set; }

        /// <summary>
        /// this setting decides the kind of UI it acts.
        /// </summary>
        UICategory UIType { get; set; }

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

        //todo: action is here, but when and how should it be called?
        IAction Action { get; set; }

        UIEntity Shape { get; set; }

        double X { get; set; }
        double Y { get; set; }
        double Height { get; set; }
        double Width { get; set; }

        IBoundUI[] Items { get; set; }
    }
}
