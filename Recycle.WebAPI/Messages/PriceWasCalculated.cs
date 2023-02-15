using System.Text.Json.Serialization;

namespace Recycle.WebAPI.Messages;

public record PriceWasCalculated
{
    [JsonPropertyName("card_id")] public string CardId { get; set; }
    [JsonPropertyName("price_amount")] public double PriceAmount { get; set; }
    [JsonPropertyName("price_currency")] public string PriceCurrency { get; set; }
}