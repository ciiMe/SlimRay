
namespace SlimRay.Data
{
    public class SimpleField : ABasicField
    {
        public SimpleField(string name, DataType type)
        {
            _name = name;
            _type = type;
            _description = "";
        }

        public SimpleField(string name, DataType type, string description)
        {
            _name = name;
            _type = type;
            _description = description;
        }
    }
}
