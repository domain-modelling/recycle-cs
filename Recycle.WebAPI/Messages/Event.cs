using System.Text.Json.Serialization;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Recycle.WebAPI.Messages;

public class Event
{
    [JsonPropertyName("type")] 
    public virtual string Type { get; }

    [JsonPropertyName("event_id")]
    public string EventId { get; } = Guid.NewGuid().ToString();

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; } = DateTime.Now;
};

public class Event<TPayload> : Event
{
    [JsonPropertyName("payload")] 
    public TPayload Payload { get;  }

    public override string Type => Payload.GetType().Name;

    public Event(TPayload payload)
    {
        Payload = payload;
    }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}