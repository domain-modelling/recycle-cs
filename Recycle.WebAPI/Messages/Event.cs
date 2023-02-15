using System.Text.Json.Serialization;

namespace Recycle.WebAPI.Messages;

public record Event
{
    [JsonPropertyName("type")] public virtual string Type { get; set; }

    [JsonPropertyName("event_id")] public string EventId { get; set; }

    [JsonPropertyName("created_at")] public DateTime CreatedAt { get; set; }
};

public record Event<TPayload> : Event
{
    [JsonPropertyName("payload")] public TPayload Payload { get; set; }

    public override string Type => Payload.GetType().Name;
}