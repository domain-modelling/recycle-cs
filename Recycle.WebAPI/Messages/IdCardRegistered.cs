using System.Text.Json.Serialization;

namespace Recycle.WebAPI.Messages;

public record IdCardRegistered
{
    [JsonPropertyName("card_id")] public string CardId { get; set; }
    [JsonPropertyName("person_id")] public string PersonId { get; set; }
    [JsonPropertyName("address")] public string Address { get; set; }
    [JsonPropertyName("city")] public string City { get; set; }
}