
namespace SlimRay.Data.Store.DB
{
    public class ExecutePlanFactory
    {
        public static IExecutePlan NewPlan()
        {
            return new SQLTextPlan();
        }

        public static ISQLPlan NewSQLPlan()
        {
            return new SQLTextPlan();
        }
    }
}
