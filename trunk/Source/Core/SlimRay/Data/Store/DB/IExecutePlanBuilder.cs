
namespace SlimRay.Data.Store.DB
{
    public interface IExecutePlanBuilder
    {
        IExecutePlan Build(ISimpleData data, Expression expression);
    }

}
