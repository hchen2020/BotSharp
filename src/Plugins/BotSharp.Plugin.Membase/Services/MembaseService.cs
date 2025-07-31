namespace BotSharp.Plugin.Membase.Services;

public partial class MembaseService : IMemoryService
{
    private readonly IServiceProvider _services;
    public MembaseService(IServiceProvider services)
    {
        _services = services;
    }
}
