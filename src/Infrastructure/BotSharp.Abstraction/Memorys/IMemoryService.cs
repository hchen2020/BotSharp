using BotSharp.Abstraction.Memorys.Models;

namespace BotSharp.Abstraction.Memorys;

public interface IMemoryService
{
    Task<MemoryResponse> MemorizeAsync(MemoryUpsertModel memory);

    Task<MemoryResponse> GetMemoryAsync(string memoryId);
    
    Task<MemoryResponse> RecallAsync(MemoryRecallRequest recall);

    Task<MemoryResponse> ForgetAsync(string memoryId);
}
