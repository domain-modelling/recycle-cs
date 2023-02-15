using System.Text.Json.Serialization;

namespace Recycle.WebAPI.Messages;

public record WeightWasMeasured
{
    [JsonPropertyName("card_id")] public string CardId { get; set; }
    [JsonPropertyName("weight")] public int Weight { get; set; }
}