
namespace SlimRay.Common
{
    public struct Action
    {
        string Name { get; set; }
    }

    public struct ActionResult
    {
        bool Success { get; set; }
        string Message { get; set; }
    }
}
