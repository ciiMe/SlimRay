
namespace SlimRay.Data
{
    public class Field : ABasicField
    {
        public Field(string name, FieldType type)
        {
            _name = name;
            _type = type;
            _description = "";
        }

        public Field(string name, FieldType type, string description)
        {
            _name = name;
            _type = type;
            _description = description;
        }
    }
}
