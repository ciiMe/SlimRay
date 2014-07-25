using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SR.Data.Entity
{
    public abstract class AComparableField : ABasicField, IField
    {
        public Expression Equal(string value)
        {
            return new Expression(this, ExpressionOperator.ValueEqual, value);
        }

        public Expression NotEqual(string value)
        {
            return new Expression(this, ExpressionOperator.ValueNotEqual, value);
        }

        public Expression Like(string value)
        {
            return new Expression(this, ExpressionOperator.ValueLike, value);
        }

        public Expression BiggerThan(string value)
        {
            return new Expression(this, ExpressionOperator.ValueBiggerThan, value);
        }

        public Expression SmallerThan(string value)
        {
            return new Expression(this, ExpressionOperator.ValueSmallerThan, value);
        }
    }
}
