
namespace SlimRay.View
{
    /// <summary>
    /// how to show the field.
    /// </summary>
    public enum FieldDisplayMethod
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
    /// when you show data in a method, you may need to format it.
    /// this is the settings to format data.
    /// </summary>
    public enum FieldDisplayFormat
    {
        Date,
        Time,
        DateTime,
        Money,
        Numeric,
        CommonText,
        Percent
    }

    public struct DataValueFormat
    {
        FieldDisplayFormat Format { get; set; }
        string FormatString { get; set; }
    }
}
