
namespace SlimRay.Data.View.Mapping
{
    public class MappedData : Data, IMapped
    {
        private string _bindingName;

        public string BindingName
        {
            get { return _bindingName; }
            set { _bindingName = value; }
        }

        public MappedData(string name)
            : base(name)
        { }

        public MappedData(string name, string description)
            : base(name, description)
        { }
    }
}
