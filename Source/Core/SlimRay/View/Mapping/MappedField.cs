
namespace SlimRay.UserData.View.Mapping
{
    public class MappedField : Field, IMapped
    {
        private string _bindingName;

        public string BindingName
        {
            get { return _bindingName; }
            set { _bindingName = value; }
        }
    }
}
