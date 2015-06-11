
namespace SlimRay.App
{
    public interface IApp
    {
        string GetName();
        string GetDescription();
        string GetKey();

        /* I am not sure when should I add these methods, so I still keep the procedures here.
         * 
         void Initialize(string parameter);
         void Start(string parameter);
         void Exit();
         */
    }
}
