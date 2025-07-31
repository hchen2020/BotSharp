using Refit;

namespace BotSharp.Plugin.Membase.Membase;

public interface IMembaseApi
{
    [Post("/graph/{graphId}/node")]
    Task<GraphNode> CreateNodeAsync(string graphId, [Body] GraphNodeCreation node);
}
