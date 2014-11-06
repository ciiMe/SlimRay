
namespace SlimRay.Data.Store.DB.Mapping
{
    public class MappedField : SimpleField, IMapped
    {
        private string _bindingName;

        public string BindingName
        {
            get { return _bindingName; }
            set { _bindingName = value; }
        }

        public MappedField(string name, DataType type)
            : base(name, type)
        { }

        public MappedField(string name, DataType type, string description)
            : base(name, type, description)
        { }
    }
}
