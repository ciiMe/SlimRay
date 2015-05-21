using SlimRay.UserData;

namespace SlimRay.View.Binding
{
    public class IBoundUIBehavior
    {
        void Bind(IUserData data);

        void Load();
        void Refresh();
        void Check();
        void Commit();
    }
}
