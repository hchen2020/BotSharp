using BotSharp.Abstraction.Agents;
using BotSharp.Abstraction.Agents.Models;

namespace BotSharp.Plugin.Membase.Hooks;

public class MembaseUtilityHook : IAgentUtilityHook
{
    private const string PREFIX = "util-memory-";
    private const string SAVE_MEMORY_FN = $"{PREFIX}save_memory";

    public void AddUtilities(List<AgentUtility> utilities)
    {
        var items = new List<AgentUtility>
        {
            new AgentUtility
            {
                Category = "memory",
                Name = "sql.tools",
                Items = [
                    new UtilityItem
                    {
                        FunctionName = SAVE_MEMORY_FN,
                        TemplateName = $"{SAVE_MEMORY_FN}.fn"
                    }
                ]
            }
        };

        utilities.AddRange(items);
    }
}
