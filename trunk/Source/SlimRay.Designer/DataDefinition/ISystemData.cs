
using SlimRay.UserData;

namespace SlimRay.Designer.DataDefinition
{
    public interface ISystemData : IData
    {
        IField CreateDate { get; }
        IField CreateUserID { get; }
        IField CreateUserAccount { get; }
    }

    public interface ISystemDataFIeld : IData
    {
        IField DataID { get; }

        IField Type { get; }
        IField MaxLength { get; }
        IField InputTip { get; }
        IField AllowNull { get; }
    }

    public interface ISystemDataLink
    {
        IField MainDataID { get; }
        IField MainFieldID { get; }
        IField Relation { get; }
        IField LinkedDataID { get; }
        IField LinkedFieldID { get; }
    }

    public interface ISystemDataLog : ILog
    {
        IField DataContentID { get; }
        IField RecoverID { get; }
    }

    public interface ISystemDataRecover
    {
        IField DataID { get; }
        IField DataContentID { get; }
        IField DataContent { get; }
    }
}
