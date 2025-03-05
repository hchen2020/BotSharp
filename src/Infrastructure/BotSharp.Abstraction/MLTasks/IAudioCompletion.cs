using System.IO;

namespace BotSharp.Abstraction.MLTasks;

public interface IAudioCompletion
{
    string Provider { get; }

    string Model { get; }

    Task<string> GenerateTextFromAudioAsync(Stream audio, string audioFileName, string? text = null);
    Task<BinaryData> GenerateAudioFromTextAsync(string text);

    void SetModelName(string model);
}
