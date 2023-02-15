using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Recycle.WebAPI.Messages;

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
    public Event Handle([FromBody] RecycleRequest request)
    {
        logger.Log(LogLevel.Information, "/handle-command request => " + JsonSerializer.Serialize(request));
        var response = new Event<PriceWasCalculated>
        {
            EventId = Guid.NewGuid().ToString(),
            CreatedAt = DateTime.Now,
            Payload = new PriceWasCalculated { CardId = "123", PriceAmount = 0, PriceCurrency = "EUR" }
        };

        logger.Log(LogLevel.Information, "/handle-command response => " + JsonSerializer.Serialize(response));
        return response;
    }
}