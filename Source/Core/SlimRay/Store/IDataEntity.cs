using SlimRay.UserData;

namespace SlimRay.Store
{
    public interface IDataEntity : IData
    {
        void SetValue(IField filed, string value);

        byte ValueByte(IField field);
        int ValueInt32(IField field);
        long ValueInt64(IField field);

        char ValueChar(IField field);
        string ValueString(IField field);

        bool ValueBool(IField field);
    }
}
