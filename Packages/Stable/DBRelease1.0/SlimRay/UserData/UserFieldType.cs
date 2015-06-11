
namespace SlimRay.UserData
{
    public enum UserFieldType
    {
        Bit,
        Byte,
        Int32,
        UnInt32,
        Int64,
        UnInt64,

        Float,

        Char,
        String,

        Boolean,

        Date,
        Time,
        DateTime,

        Emun,

        /*
         * this field is linked to another one,
         * the type will be the same as the field it linkes.
         */
        Linked
    }
}
