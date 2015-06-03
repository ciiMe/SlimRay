using SlimRay.App;

namespace SlimRay.DB
{
    public interface IExecutorCreator : IApp
    {
        IExecutor New();
    }
}
