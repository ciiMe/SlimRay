
namespace SlimRay.App
{
    /*
     * the gate shows all apps provided by SlimRay,
     * but,
     * should I create another singleton object?
     */
    public interface IGate
    {
        /// <summary>
        /// get app which is started, the app is sorted in app pool.
        /// </summary>
        IApp Get(string key);

        /// <summary>
        /// unload apps in app pool.
        /// </summary>
        /// <param name="key"></param>
        void Unload(string key);

        /// <summary>
        /// create new instance of an app.
        /// </summary>
        IApp CreateNew(string key);
    }
}
