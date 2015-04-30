
using SlimRay.UserData;
using SlimRay.Common;
using System.Data;

namespace SlimRay.View.DataAdapter
{
    public interface IDataAdapter
    {
        string GetFieldValue(IUserField field);
        ActionResult UpdateFieldValue(IUserField field, string value);

        DataTable GetAll(IUserData data);
    }
}
