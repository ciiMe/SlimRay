using SlimRay.UserData;

namespace SlimRay.View.Binding.DataAdapter
{
    public class DataLoader
    {
        public static string LoadUserDataValue(IUserField field)
        {
            return field.Name + "'s value";
        }
    }
}
