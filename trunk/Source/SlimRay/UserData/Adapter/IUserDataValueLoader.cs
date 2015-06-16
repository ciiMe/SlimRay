using SlimRay.DB;
using System.Data;

namespace SlimRay.UserData.Adapter
{
    public interface IUserDataValueLoader
    {
        string Load(IUserField field);
        DataTable Load(IUserData data);
        //todo: load by expression??
        
        bool Save(IUserField field, string value);
        bool Save(FieldValueCollection data);
    }
}
