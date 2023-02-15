using System.Text.Json.Serialization;

namespace Recycle.WebAPI.Messages;

public class Event
{
    [JsonPropertyName("type")] public virtual string Type { get; set; }

    [JsonPropertyName("event_id")] public string EventId { get; set; }

    [JsonPropertyName("created_at")] public DateTime CreatedAt { get; set; }
};

public class Event<TPayload> : Event
{
    [JsonPropertyName("payload")] public TPayload Payload { get; set; }

    public Event(TPayload payload)
    {
        Payload = payload;
        Type = payload.GetType().Name;
    }
}