
using SlimRay.Data.Store.Operators;

namespace SlimRay.Data.Store.DB.Mapping
{
    public class SQLPlanBuilder : IExecutePlanBuilder
    {
        private static string ToSQLWithParameter(Expression expr, IExecutePlan plan)
        {
            if (expr.Operator == ExpressionOperator.None)
            {
                string pName = string.Format("@p{0}", plan.Parameters.Count);
                string pVal = expr.Field is IMapped ? (expr.Field as IMapped).BindingName : expr.Field.Name;

                plan.AddParameter(pName, pVal);
                return pName;
            }

            string field = expr.Field is IMapped ? (expr.Field as IMapped).BindingName : expr.Field.Name;
            string op = OperatorServer.ActiveService.Parse(expr.Operator);

            return string.Format("{0} {1} {2}", field, op, ToSQLWithParameter(expr.Value, plan));
        }

        private static string ToSQL(Expression expr)
        {
            if (expr.Operator == ExpressionOperator.None)
            {
                return expr.Field is IMapped ? (expr.Field as IMapped).BindingName : expr.Field.Name;
            }

            string field = expr.Field is IMapped ? (expr.Field as IMapped).BindingName : expr.Field.Name;
            string op = Operators.OperatorServer.ActiveService.Parse(expr.Operator);

            return string.Format("{0} {1} {2}", field, op, ToSQL(expr.Value));
        }

        public IExecutePlan Build(ISimpleData data, Expression expression)
        {
            SQLTextPlan plan = new SQLTextPlan();

            string table = data is IMapped ? (data as IMapped).BindingName : data.Name;
            string cond = ToSQLWithParameter(expression, plan);

            plan.CommandText = string.Format("select * from {0} where {1}", table, cond);

            return plan;
        }
    }
}
