
namespace SlimRay.Data.SysData
{
    public interface ISystemDataHelper
    {
        string[] GetDataList();
        bool AddData(string name, string displayName);
        bool RemoveData(string name);
        bool UpdateData(string dataName, string newDisplayName);

        string[] GetFields(string dataName);
        bool AddField(string dataName, string name, string displayName, int type);
        bool RemoveField(string dataName, string name);
        bool UpdateField(string dataName, string name, string newDisplayName, int newType);
    }
}
