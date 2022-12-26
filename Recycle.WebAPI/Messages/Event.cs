using System.Text.Json;
using System.Text.Json.Serialization;

namespace Recycle.WebAPI.Messages;

public class Event
{
    [JsonPropertyName("event_id")]
    public string EventId { get; } = Guid.NewGuid().ToString();

    
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; } = DateTime.Now;

    [JsonPropertyName("type")] 
    public string Type { get; }

    public Event(string type)
    {
        Type = type;
    }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}