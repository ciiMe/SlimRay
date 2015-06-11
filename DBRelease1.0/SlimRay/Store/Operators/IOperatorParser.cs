using SlimRay.UserData;

namespace SlimRay.Store.Operators
{
    public interface IOperatorParser
    {
        string Parse(ExpressionOperator op);
    }
}
