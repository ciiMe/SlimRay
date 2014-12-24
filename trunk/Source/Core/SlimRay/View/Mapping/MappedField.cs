
namespace SlimRay.Data.View.Mapping
{
    public class MappedField : Field, IMapped
    {
        private string _bindingName;

        public string BindingName
        {
            get { return _bindingName; }
            set { _bindingName = value; }
        }

        public MappedField(string name, FieldType type)
            : base(name, type)
        { }

        public MappedField(string name, FieldType type, string description)
            : base(name, type, description)
        { }
    }
}
