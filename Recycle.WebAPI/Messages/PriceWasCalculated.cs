using System.Text.Json.Serialization;

namespace Recycle.WebAPI.Messages;

public class PriceWasCalculated : Event
{
    public static PriceWasCalculated Build (string personId, int priceAmount, string priceCurrency)
    {
        return new PriceWasCalculated(new Data(personId, priceAmount, priceCurrency));
    }
    
    [JsonPropertyName("payload")] public Data Payload { get; }

    private PriceWasCalculated(Data data) : base("PriceWasCalculated")
    {
        this.Payload = data;
    }

    public class Data
    {
        [JsonPropertyName("person_id")] public string PersonId { get; }
        [JsonPropertyName("price_amount")] public double PriceAmount { get; }
        [JsonPropertyName("price_currency")] public string PriceCurrency { get; }

        public Data(string personId, double priceAmount, string priceCurrency)
        {
            PersonId = personId;
            PriceAmount = priceAmount;
            PriceCurrency = priceCurrency;
        }
    }
}