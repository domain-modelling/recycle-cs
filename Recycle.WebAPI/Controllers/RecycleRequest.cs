using System.Text.Json.Serialization;
using Recycle.WebAPI.Messages;

namespace Recycle.WebAPI.Controllers;

public class RecycleRequest
{
    [JsonPropertyName("command")] public Command Command { get; set; }
    [JsonPropertyName("history")] public List<Event> History { get; set; } 
}