
using SlimRay.UserData;
using SlimRay.Common;
using System.Data;

namespace SlimRay.View.DataAdapter
{
    public interface IDataAdapter
    {
        string GetFieldValue(IField field);
        ActionResult UpdateFieldValue(IField field, string value);

        DataTable GetAll(IData data);
    }
}
