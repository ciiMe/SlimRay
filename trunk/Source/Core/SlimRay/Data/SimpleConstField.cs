
namespace SlimRay.Data
{
    public class SimpleConstField : ABasicField
    {
        public SimpleConstField(string value, DataTypes type)
        {
            _value = value;
            _type = type;
        }

        public SimpleConstField(string value)
        {
            _value = value;
            _type = DataTypes.NotSet;
        }
    }
}
