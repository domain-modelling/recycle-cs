using System.Text.Json.Serialization;

namespace Recycle.WebAPI.Messages;

public record Command
{
    [JsonPropertyName("type")] public virtual string Type { get; set; }

    [JsonPropertyName("command_id")] public string CommandId { get; set; }

    [JsonPropertyName("created_at")] public DateTime CreatedAt { get; set; }
};

public record Command<TPayload> : Command
{
    [JsonPropertyName("payload")] public TPayload Payload { get; set; }

    public override string Type => Payload.GetType().Name;
}