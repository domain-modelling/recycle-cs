using System.Text.Json.Serialization;

namespace Recycle.WebAPI.Messages;

public record IdCardScannedAtEntranceGate
{
    [JsonPropertyName("card_id")] public string CardId { get; set; }
}