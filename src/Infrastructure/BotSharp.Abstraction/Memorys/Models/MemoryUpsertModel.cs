namespace BotSharp.Abstraction.Memorys.Models;

public class MemoryUpsertModel
{
    /// <summary>
    /// Required for update operation.
    /// </summary>
    public string? MemoryId { get; set; }

    /// <summary>
    /// Set user id to associate the memory with a specific user.
    /// </summary>
    public string? UserId { get; set; }

    /// <summary>
    /// Set agent id to associate the memory with a specific agent.
    /// </summary>
    public string? AgentId { get; set; }
}
