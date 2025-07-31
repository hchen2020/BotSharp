using BotSharp.Abstraction.Agents;
using BotSharp.Abstraction.Plugins;
using BotSharp.Plugin.Membase.Hooks;
using BotSharp.Plugin.Membase.Membase;
using Refit;

namespace BotSharp.Plugin.Membase;

public class MembasePlugin : IBotSharpPlugin
{
    public string Id => "89e24056-0421-4a65-8437-f535b0ef9ad6";
    public string Name => "Membase";
    public string Description => "Document-oriented database that seamlessly integrates graph traversal and vector search capabilities";
    public string IconUrl => "https://www.membase.dev/favicon.png";

    public void RegisterDI(IServiceCollection services, IConfiguration config)
    {
        services.AddScoped<IAgentUtilityHook, MembaseUtilityHook>();

        services.AddRefitClient<IMembaseApi>()
            .ConfigureHttpClient((sp, c) => c.BaseAddress = new Uri("https//api.membase.dev"));
            //.AddHttpMessageHandler<MeshAuthHeaderHandler>();
    }
}
