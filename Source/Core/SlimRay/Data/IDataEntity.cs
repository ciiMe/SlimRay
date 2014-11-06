
namespace SlimRay.Data
{
    public interface IDataEntity : ISimpleData
    {
        void SetValue(ISimpleField filed, string value);

        byte ValueByte(ISimpleField field);
        int ValueInt32(ISimpleField field);
        long ValueInt64(ISimpleField field);

        char ValueChar(ISimpleField field);
        string ValueString(ISimpleField field);

        bool ValueBool(ISimpleField field);
    }
}
