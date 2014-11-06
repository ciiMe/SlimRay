
namespace SlimRay.Data
{
    public class Expression
    {
        private ISimpleField _field;
        private ExpressionOperator _operator;
        private Expression _sub;

        public ISimpleField Field
        {
            get { return _field; }
            set { _field = value; }
        }

        public ExpressionOperator Operator
        {
            get { return _operator; }
            set { _operator = value; }
        }

        public Expression Sub
        {
            get { return _sub; }
            set { _sub = value; }
        }

        public Expression()
        {
        }

        public Expression(ISimpleField field, ExpressionOperator op, string value)
        {
            _field = field;
            _operator = op;
            _sub = new Expression
            {
                Field = new SimpleConstField(value),
                Operator = ExpressionOperator.None
            };
        }

        public Expression(ISimpleField field, ExpressionOperator op, ISimpleField value)
        {
            _field = field;
            _operator = op;
            _sub = new Expression
            {
                Field = value,
                Operator = ExpressionOperator.None
            };
        }

        public Expression(ISimpleField field, ExpressionOperator op, Expression sub)
        {
            _field = field;
            _operator = op;
            _sub = sub;
        }

        public Expression(Expression e1, ExpressionOperator op, Expression e2)
        {

        }

        #region operator override

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        #region calculate operators

        public static Expression operator +(Expression e1, Expression e2)
        {
            return new Expression(e1, ExpressionOperator.ValueAdd, e2);
        }
        public static Expression operator -(Expression e1, Expression e2)
        {
            return new Expression(e1, ExpressionOperator.ValueAdd, e2);
        }
        public static Expression operator *(Expression e1, Expression e2)
        {
            return new Expression(e1, ExpressionOperator.ValueMul, e2);
        }
        public static Expression operator /(Expression e1, Expression e2)
        {
            return new Expression(e1, ExpressionOperator.ValueDiv, e2);
        }
        public static Expression operator %(Expression e1, Expression e2)
        {
            return new Expression(e1, ExpressionOperator.ValueMod, e2);
        }
        public static Expression operator ^(Expression e1, Expression e2)
        {
            return new Expression(e1, ExpressionOperator.ValuePower, e2);
        }

        #endregion

        #region logic operators

        /*
         * logic operators can not be overridden,
         * override bit operator instead.
         */
        public static Expression operator &(Expression e1, Expression e2)
        {
            return new Expression(e1, ExpressionOperator.LogicAnd, e2);
        }
        public static Expression operator |(Expression e1, Expression e2)
        {
            return new Expression(e1, ExpressionOperator.LogicOr, e2);
        }
        public static Expression operator !(Expression e1)
        {
            return new Expression(e1, ExpressionOperator.LogicNot, e1);
        }

        public static Expression operator ==(Expression e1, Expression e2)
        {
            return new Expression(e1, ExpressionOperator.ValueEqual, e2);
        }
        public static Expression operator !=(Expression e1, Expression e2)
        {
            return new Expression(e1, ExpressionOperator.ValueNotEqual, e2);
        }

        public static Expression operator >(Expression e1, Expression e2)
        {
            return new Expression(e1, ExpressionOperator.ValueBiggerThan, e2);
        }
        public static Expression operator <(Expression e1, Expression e2)
        {
            return new Expression(e1, ExpressionOperator.ValueSmallerThan, e2);
        }
        public static Expression operator >=(Expression e1, Expression e2)
        {
            return new Expression(e1, ExpressionOperator.ValueBiggerOrEqual, e2);
        }
        public static Expression operator <=(Expression e1, Expression e2)
        {
            return new Expression(e1, ExpressionOperator.ValueSmallerOrEqual, e2);
        }

        #endregion

        #endregion
    }
}
