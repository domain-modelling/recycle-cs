using System.Text.Json.Serialization;

namespace Recycle.WebAPI.Messages;

public class PriceWasCalculated
{
    [JsonPropertyName("card_id")] public string CardId { get; }
    [JsonPropertyName("price_amount")] public double PriceAmount { get; }
    [JsonPropertyName("price_currency")] public string PriceCurrency { get; }

    public PriceWasCalculated(string cardId, double priceAmount, string priceCurrency)
    {
        CardId = cardId;
        PriceAmount = priceAmount;
        PriceCurrency = priceCurrency;
    }

    protected bool Equals(PriceWasCalculated other)
    {
        return CardId == other.CardId
               && PriceAmount.Equals(other.PriceAmount)
               && PriceCurrency == other.PriceCurrency;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((PriceWasCalculated)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(CardId, PriceAmount, PriceCurrency);
    }

    public override string ToString()
    {
        return $"CardId: {CardId}: {PriceAmount}{PriceCurrency}";
    }
}