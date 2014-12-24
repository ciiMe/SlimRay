using SlimRay.Utils;

namespace SlimRay.Data.Store.Operators
{
    public class ParserMSSQL : IOperatorParser
    {
        Translator<ExpressionOperator, string> _translator;

        public ParserMSSQL()
        {
            _translator = new Translator<ExpressionOperator, string>();
            MakePairs();
        }

        private void MakePairs()
        {
            _translator.Pair(ExpressionOperator.ValueAdd, "+");
            _translator.Pair(ExpressionOperator.ValueSub, "-");
            _translator.Pair(ExpressionOperator.ValueMul, "*");
            _translator.Pair(ExpressionOperator.ValueDiv, "/");
            _translator.Pair(ExpressionOperator.ValuePower, "^");

            _translator.Pair(ExpressionOperator.ValueEqual, "=");
            _translator.Pair(ExpressionOperator.ValueNotEqual, "<>");
            _translator.Pair(ExpressionOperator.ValueLike, "like");

            _translator.Pair(ExpressionOperator.ValueBiggerThan, ">");
            _translator.Pair(ExpressionOperator.ValueBiggerOrEqual, ">=");
            _translator.Pair(ExpressionOperator.ValueSmallerThan, "<");
            _translator.Pair(ExpressionOperator.ValueSmallerOrEqual, "<=");

            _translator.Pair(ExpressionOperator.LogicAnd, "and");
            _translator.Pair(ExpressionOperator.LogicNot, "not");
            _translator.Pair(ExpressionOperator.LogicOr, "or");
        }

        public string Parse(ExpressionOperator op)
        {
            return _translator.Translate(op);
        }
    }
}
