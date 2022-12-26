using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace Recycle.WebAPI.Controllers;

[Route("/handle-command")]
public class HandlingController
{
    private readonly ILogger<HandlingController> logger;

    public HandlingController(ILogger<HandlingController> logger)
    {
        this.logger = logger;
    }

    [HttpPost]
    public Event Handle(IList<Event> events, Command command)
    {
        logger.Log(LogLevel.Information, "/handle-command succeeded");
        logger.Log(LogLevel.Information, "events " + events);
        logger.Log(LogLevel.Information, "command " + command);
        return new PriceWasCalculated();
    }
}

public class PriceWasCalculated : Event
{
    [JsonPropertyName("payload")]
    public Payload payload { get; private set; }
    public PriceWasCalculated() : base("PriceWasCalculated")
    {
        payload = new Payload();
    }

    public class Payload
    {
        [JsonPropertyName("person_id")] public string PersonId { get; } = "Tom";

        [JsonPropertyName("price_amount")] public double PriceAmount { get; } = 0;

        [JsonPropertyName("price_currency")] public string PriceCurrency { get; } = "EUR";
    }
}

public class Event
{
    [JsonPropertyName("event_id")]
    public string EventId { get; } = Guid.NewGuid().ToString();

    
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; } = DateTime.Now;

    [JsonPropertyName("type")] 
    public string Type { get; }

    public Event(string type)
    {
        Type = type;
    }
}

    // {
    // event_id: "foo",
    // created_at: new Date().toISOString(),
    // type: "PriceWasCalculated",
    // payload: {
    // person_id: "Tom",
    // price_amount: 0,
    // price_currency: "EUR",
    // },

public class Command
{
}