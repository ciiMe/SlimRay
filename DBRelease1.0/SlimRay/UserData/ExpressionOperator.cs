
namespace SlimRay.UserData
{
    public enum ExpressionOperator
    {
        /// <summary>
        /// None means no operator in expression,
        /// it may be a const value,or end of expression.
        /// </summary>
        None,

        ValueAdd,
        ValueSub,
        ValueMul,
        ValueDiv,
        ValueMod,
        ValuePower,

        ValueEqual,
        ValueNotEqual,
        ValueLike,

        ValueBiggerThan,
        ValueBiggerOrEqual,
        ValueSmallerThan,
        ValueSmallerOrEqual,

        LogicAnd,
        LogicOr,
        LogicNot
    }
}
