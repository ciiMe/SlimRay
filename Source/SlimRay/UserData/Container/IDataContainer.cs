
namespace SlimRay.UserData.Container
{
    /// <summary>
    /// a container is a storage space that can save data,
    /// it provide portal to read and write data's value.
    /// </summary>
    public interface IDataContainer
    {
        IUserData Definition { get; }

        void SetValue(IUserField filed, string value);

        byte GetValueAsByte(IUserField field);
        int GetValueAsInt32(IUserField field);
        long ValuGetValueAsInt64(IUserField field);

        char ValuGetValueAsChar(IUserField field);
        string GetValueAsString(IUserField field);

        bool GetValueAsBool(IUserField field);
    }
}
