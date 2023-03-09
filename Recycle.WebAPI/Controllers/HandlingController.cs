using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Recycle.WebAPI.Messages;
using Recycle.WebAPI.Middleware;

namespace Recycle.WebAPI.Controllers;

[ApiController]
[Route("/handle-command")]
public class HandlingController
{
    [HttpPost]
    public string Handle([FromBody] RecycleRequest request)
    {
        Event response = new Event<PriceWasCalculated>
        {
            EventId = Guid.NewGuid().ToString(),
            CreatedAt = DateTime.Now,
            Payload = new PriceWasCalculated { CardId = "321", PriceAmount = 0, PriceCurrency = "EUR" }
        };
        return JsonSerializer.Serialize(response, JsonSerializationConfiguration.Default);
    }
}