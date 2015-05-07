using SlimRay.UserData;

namespace SlimRay.UserData
{
    public class Expression
    {
        private IUserField _field;
        private ExpressionOperator _operator;

        private Expression _value;

        public IUserField Field
        {
            get { return _field; }
            set { _field = value; }
        }

        public ExpressionOperator Operator
        {
            get { return _operator; }
            set { _operator = value; }
        }

        public Expression Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public Expression(string value)
        {

        }

        public Expression(IUserField field, ExpressionOperator op, string val)
        {
        }

        public Expression(IUserField field1, ExpressionOperator op, IUserField field2)
        {
        }

        public Expression(IUserField field, ExpressionOperator op, Expression sub)
        {
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
