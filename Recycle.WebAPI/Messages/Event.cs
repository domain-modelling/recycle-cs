using System.Text.Json.Serialization;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Recycle.WebAPI.Messages;

public class Event
{
    [JsonPropertyName("type")] 
    public string Type { get; private protected set; }

    [JsonPropertyName("event_id")]
    public string EventId { get; } = Guid.NewGuid().ToString();

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; } = DateTime.Now;

};

public class Event<TPayload> : Event
{
    [JsonPropertyName("payload")] 
    public TPayload Payload { get; }
    
    public Event(TPayload payload)
    {
        Type = payload.GetType().Name;
        Payload = payload;
    }


    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}