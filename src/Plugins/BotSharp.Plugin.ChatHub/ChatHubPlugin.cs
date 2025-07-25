using BotSharp.Abstraction.Crontab;
using BotSharp.Abstraction.Observables.Models;
using BotSharp.Core.Observables.Queues;
using BotSharp.Plugin.ChatHub.Hooks;
using BotSharp.Plugin.ChatHub.Observers;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace BotSharp.Plugin.ChatHub;

/// <summary>
/// The dialogue channel connects users, AI assistants and customer service representatives.
/// </summary>
public class ChatHubPlugin : IBotSharpPlugin, IBotSharpAppPlugin
{
    public string Id => "6e52d42d-1e23-406b-8599-36af36c83209";
    public string Name => "Chat Hub";
    public string Description => "A communication channel connects agents and users in real-time.";
    public string IconUrl => "https://media.zeemly.com/media/product/chatrandom.png";

    public void RegisterDI(IServiceCollection services, IConfiguration config)
    {
        var settings = new ChatHubSettings();
        config.Bind("ChatHub", settings);
        services.AddSingleton(x => settings);

        // Register hooks
        services.AddScoped<IConversationHook, ChatHubConversationHook>();
        services.AddScoped<IConversationHook, StreamingLogHook>();
        services.AddScoped<IConversationHook, WelcomeHook>();
        services.AddScoped<IRoutingHook, StreamingLogHook>();
        services.AddScoped<IContentGeneratingHook, StreamingLogHook>();
        services.AddScoped<ICrontabHook, ChatHubCrontabHook>();
    }

    public void Configure(IApplicationBuilder app)
    {
        var services = app.ApplicationServices;
        var queue = services.GetRequiredService<MessageHub<HubObserveData>>();
        var logger = services.GetRequiredService<ILogger<MessageHub<HubObserveData>>>();
        queue.Events.Subscribe(new ChatHubObserver(logger));
    }
}
