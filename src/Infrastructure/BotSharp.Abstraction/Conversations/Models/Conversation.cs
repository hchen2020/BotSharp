using BotSharp.Abstraction.Conversations.Enums;

namespace BotSharp.Abstraction.Conversations.Models;

public class Conversation
{
    public string Id { get; set; } = string.Empty;
    public string AgentId { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;

    /// <summary>
    /// Agent task id
    /// </summary>
    public string? TaskId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string TitleAlias { get; set; } = string.Empty;

    [JsonIgnore]
    public List<DialogElement> Dialogs { get; set; } = [];

    [JsonIgnore]
    public Dictionary<string, string> States { get; set; } = [];

    public string Status { get; set; } = ConversationStatus.Open;

    public string Channel { get; set; } = ConversationChannel.OpenAPI;

    /// <summary>
    /// Channel id, like phone number, email address, etc.
    /// </summary>
    public string ChannelId { get; set; } = default!;

    public int DialogCount { get; set; }

    public List<string> Tags { get; set; } = [];

    public DateTime UpdatedTime { get; set; } = DateTime.UtcNow;
    public DateTime CreatedTime { get; set; } = DateTime.UtcNow;
}

public class DialogElement
{
    [JsonPropertyName("meta_data")]
    public DialogMetaData MetaData { get; set; } = new();

    [JsonPropertyName("content")]
    public string Content { get; set; } = default!;

    [JsonPropertyName("secondary_content")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? SecondaryContent { get; set; }

    [JsonPropertyName("rich_content")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? RichContent { get; set; }

    [JsonPropertyName("secondary_rich_content")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? SecondaryRichContent { get; set; }

    [JsonPropertyName("payload")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Payload { get; set; }

    public DialogElement()
    {

    }

    public DialogElement(DialogMetaData meta, string content, string? richContent = null,
        string? secondaryContent = null, string? secondaryRichContent = null, string? payload = null)
    {
        MetaData = meta;
        Content = content;
        RichContent = richContent;
        SecondaryContent = secondaryContent;
        SecondaryRichContent = secondaryRichContent;
        Payload = payload;
    }

    public override string ToString()
    {
        return $"{MetaData.Role}: {Content} [{MetaData?.CreatedTime}]";
    }
}

public class DialogMetaData
{
    [JsonPropertyName("role")]
    public string Role { get; set; } = default!;

    [JsonPropertyName("agent_id")]
    public string AgentId { get; set; } = default!;

    [JsonPropertyName("message_id")]
    public string MessageId { get; set; } = default!;

    [JsonPropertyName("message_type")]
    public string MessageType { get; set; } = default!;

    [JsonPropertyName("function_name")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? FunctionName { get; set; }

    [JsonPropertyName("function_args")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? FunctionArgs { get; set; }

    [JsonPropertyName("tool_call_id")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ToolCallId { get; set; }

    [JsonPropertyName("sender_id")]
    public string? SenderId { get; set; }

    [JsonPropertyName("create_at")]
    public DateTime CreatedTime { get; set; }
}
