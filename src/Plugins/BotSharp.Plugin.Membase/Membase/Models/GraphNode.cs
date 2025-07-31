namespace BotSharp.Plugin.Membase.Membase.Models;

public class GraphNode
{
    public string Id { get; set; }= string.Empty;
    public string[] Labels { get; set; } = [];
    public Dictionary<string, object> Properties { get; set; } = new Dictionary<string, object>();
}
