
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
        IAPP Get(string key);

        /// <summary>
        /// unload apps in app pool.
        /// </summary>
        void Unload(string key);

        /// <summary>
        /// create new instance of an app.
        /// </summary>
        IAPP CreateNew(string key);
    }
}
