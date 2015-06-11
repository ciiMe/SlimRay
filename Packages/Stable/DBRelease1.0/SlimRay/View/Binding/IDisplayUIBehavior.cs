using SlimRay.UserData;

namespace SlimRay.View.Binding
{
    public interface IDisplayUIBehavior
    {
        void Bind(IUserData data);

        void Load();
        void Refresh();
    }
}
