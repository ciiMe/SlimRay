
namespace SlimRay.Data
{
    /* all data heleprs register themself in this gate,
     * 
     * and, this gate is not a true gate, it's an adapter connect to AppGate.
     */
    public class DataHelperGate
    {
        private static DataHelperGate _instance = new DataHelperGate();

        public static DataHelperGate Instance
        {
            get { return DataHelperGate._instance; }
            set { DataHelperGate._instance = value; }
        }

        public IDataAccessApp GetDataAccessApp(string storageKey)
        {
            //todo: get real apps from appGate.
            return null;
        }
    }
}
