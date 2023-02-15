using System.Text.Json.Serialization;

namespace Recycle.WebAPI.Messages;

public record IdCardScannedAtEntranceGate
{
    [JsonPropertyName("card_id")] public string CardId { get; set; }
}

public record IdCardScannedAtExitGate
{
    [JsonPropertyName("card_id")] public string CardId { get; set; }
}

public record FractionWasSelected
{
    [JsonPropertyName("card_id")] public string CardId { get; set; }
    [JsonPropertyName("fraction_type")] public string FractionType { get; set; }
}