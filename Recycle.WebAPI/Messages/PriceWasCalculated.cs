using System.Text.Json.Serialization;

namespace Recycle.WebAPI.Messages;

public class PriceWasCalculated
{
    [JsonPropertyName("person_id")] public string PersonId { get; }
    [JsonPropertyName("price_amount")] public double PriceAmount { get; }
    [JsonPropertyName("price_currency")] public string PriceCurrency { get; }

    public PriceWasCalculated(string personId, double priceAmount, string priceCurrency)
    {
        PersonId = personId;
        PriceAmount = priceAmount;
        PriceCurrency = priceCurrency;
    }

    protected bool Equals(PriceWasCalculated other)
    {
        return PersonId == other.PersonId
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
        return HashCode.Combine(PersonId, PriceAmount, PriceCurrency);
    }
}