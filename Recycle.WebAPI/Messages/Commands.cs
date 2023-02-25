using System.Text.Json.Serialization;

namespace Recycle.WebAPI.Messages;

public record Command
{
    [JsonPropertyName("command_id")] public string CommandId { get; set; }
    [JsonPropertyName("created_at")] public DateTime CreatedAt { get; set; }
};

public record Command<TPayload> : Command
{
    [JsonPropertyName("payload")] public TPayload Payload { get; set; }
}

public record CalculatePrice
{
    [JsonPropertyName("card_id")] public string CardId { get; set; }
}