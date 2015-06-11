
namespace SlimRay.UserData
{
    public interface IUserField
    {
        /// <summary>
        /// The data that this filed belongs to.
        /// </summary>
        IUserData Data { get; set; }

        int ID { get; set; }
        string Name { get; set; }
        string Description { get; set; }

        UserFieldType Type { get; set; }
    }
}
