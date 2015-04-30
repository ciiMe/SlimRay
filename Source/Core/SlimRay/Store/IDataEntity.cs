using SlimRay.UserData;

namespace SlimRay.Store
{
    public interface IDataEntity : IUserData
    {
        void SetValue(IUserField filed, string value);

        byte ValueByte(IUserField field);
        int ValueInt32(IUserField field);
        long ValueInt64(IUserField field);

        char ValueChar(IUserField field);
        string ValueString(IUserField field);

        bool ValueBool(IUserField field);
    }
}
