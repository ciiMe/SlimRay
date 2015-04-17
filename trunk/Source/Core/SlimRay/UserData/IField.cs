
namespace SlimRay.UserData
{
    public enum FieldDisplayType
    {
        AsText,

        AsDropdownList,
        AsSelectOnlyDropDownList,

        AsRadio,
        AsCheckable,

        AsCanlendar
    }

    public enum DataValueFormatType
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
        DataValueFormatType Format { get; set; }
        string FormatString { get; set; }
    }

    public interface IField
    {
        /// <summary>
        /// The data that this filed belongs to.
        /// </summary>
        IData Data { get; set; }

        int ID { get; set; }
        string Name { get; set; }
        string Description { get; set; }

        FieldType Type { get; set; }
        FieldDisplayType DisplayType { get; set; }
        DataValueFormat DisplayFormat { get; set; }
    }
}
