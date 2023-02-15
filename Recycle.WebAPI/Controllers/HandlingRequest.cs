using System.Text.Json.Serialization;
using Recycle.WebAPI.Messages;

namespace Recycle.WebAPI.Controllers;

public class HandlingRequest
{
    [JsonPropertyName("command")]
    public Event Command { get; set; }
    [JsonPropertyName("history")]
    public List<Event> History { get; set; } 
}