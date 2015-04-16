using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

    public struct IBindingShape
    {
    }

    public interface IBindingConfig
    {
        double X { get; set; }
        double Y { get; set; }

        IBindingShape Shage { get; set; }

        double height { get; set; }
        double width { get; set; }

        BindingItem[] Items { get; set; }
    }

    public struct BindingItem
    {
        int DataID { get; set; }
        int FieldID { get; set; }
    }
}
