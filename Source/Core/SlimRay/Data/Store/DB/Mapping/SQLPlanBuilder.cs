
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

                plan.AddParameter(pName, expr.Field.Value);
                return pName;
            }

            string field = expr.Field is Mapping.IMapped ? (expr.Field as Mapping.IMapped).BindingName : expr.Field.Name;
            string op = OperatorServer.ActiveService.Parse(expr.Operator);

            return string.Format("{0} {1} {2}", field, op, ToSQLWithParameter(expr.Sub, plan));
        }

        private static string ToSQL(Expression expr)
        {
            if (expr.Operator == ExpressionOperator.None)
            {
                return expr.Field.Value;
            }

            string field = expr.Field is Mapping.IMapped ? (expr.Field as Mapping.IMapped).BindingName : expr.Field.Name;
            string op = Operators.OperatorServer.ActiveService.Parse(expr.Operator);

            return string.Format("{0} {1} {2}", field, op, ToSQL(expr.Sub));
        }

        public IExecutePlan Build(ISimpleData data, Expression expression)
        {
            SQLTextPlan plan = new SQLTextPlan();

            string table = data is Mapping.IMapped ? (data as Mapping.IMapped).BindingName : data.Name;
            string cond = ToSQLWithParameter(expression, plan);

            plan.CommandText = string.Format("select * from {0} where {1}", table, cond);

            return plan;
        }
    }
}
