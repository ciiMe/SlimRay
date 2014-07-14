using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SR.Data.DB;

namespace SR.Data.Manager
{
    internal class ExecutePlanBuilder
    {
        /// <summary>
        /// DO NOT call this method!
        /// It is written only for updated version in feature,
        /// we only use SQLPlan right now,
        /// ExecutePlan will be used in later versions.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="expr"></param>
        /// <returns></returns>
        internal static IExecutePlan BuildExecutePlan(IData data, IExpression expr)
        {
            return ExecutePlanFactory.NewSQLPlan();
        }

        internal static ISQLPlan BuildSQLPlan(IData data, IExpression expr)
        {
            return new SQLTextPlan();
        }
    }
}
