namespace BotSharp.Plugin.Membase.Membase.Models;

public class GraphNodeCreation
{
    public string[] Labels { get; set; } = [];
    public Dictionary<string, object> Properties { get; set; } = new Dictionary<string, object>();
}
