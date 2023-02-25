using System.Text.Json.Serialization;

namespace Recycle.WebAPI.Messages;

public record Event
{
    [JsonPropertyName("type")] public virtual string Type { get; set; }
    [JsonPropertyName("event_id")] public string EventId { get; set; }
    [JsonPropertyName("created_at")] public DateTime CreatedAt { get; set; }
};

public record Event<TPayload> : Event
{
    private TPayload payload;

    [JsonPropertyName("payload")]
    public TPayload Payload
    {
        get => payload;
        set
        {
            payload = value;
            Type = value.GetType().Name;
        }
    }
}

public record IdCardRegistered
{
    [JsonPropertyName("card_id")] public string CardId { get; set; }
    [JsonPropertyName("person_id")] public string PersonId { get; set; }
    [JsonPropertyName("address")] public string Address { get; set; }
    [JsonPropertyName("city")] public string City { get; set; }
}

public record IdCardScannedAtEntranceGate
{
    [JsonPropertyName("card_id")] public string CardId { get; set; }
}

public record FractionWasSelected
{
    [JsonPropertyName("card_id")] public string CardId { get; set; }
    [JsonPropertyName("fraction_type")] public string FractionType { get; set; }
}

public record WeightWasMeasured
{
    [JsonPropertyName("card_id")] public string CardId { get; set; }
    [JsonPropertyName("weight")] public int Weight { get; set; }
}

public record FractionWasDropped
{
    [JsonPropertyName("card_id")] public string CardId { get; set; }
    [JsonPropertyName("fraction_type")] public string FractionType { get; set; }
    [JsonPropertyName("weight")] public int Weight { get; set; }
}

public record IdCardScannedAtExitGate
{
    [JsonPropertyName("card_id")] public string CardId { get; set; }
}

public record PriceWasCalculated
{
    [JsonPropertyName("card_id")] public string CardId { get; set; }
    [JsonPropertyName("price_amount")] public double PriceAmount { get; set; }
    [JsonPropertyName("price_currency")] public string PriceCurrency { get; set; }
}