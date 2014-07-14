using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SR.Data.DB
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
