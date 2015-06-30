using SlimRay.App;

namespace SlimRay.DB
{
    public interface IExecutorCreator : IAPP
    {
        IExecutor New();
    }
}
