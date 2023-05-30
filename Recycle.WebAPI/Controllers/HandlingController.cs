using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Recycle.WebAPI.Domain;
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
        var command = CommandOf(request);
        
        // If you have no inspiration to start implementing, uncomment this part:
        // var amount = new PriceCalculator(request.History).CalculatePrice(command.CardId);
        const int amount = 1;

        return JsonSerializer.Serialize((Event)new Event<PriceWasCalculated>
        {
            EventId = Guid.NewGuid().ToString(),
            CreatedAt = DateTime.Now,
            Payload = new PriceWasCalculated { CardId = command.CardId, PriceAmount = amount, PriceCurrency = "EUR" }
        }, JsonSerializationConfiguration.Default);
    }

    private CalculatePrice CommandOf(RecycleRequest request)
    {
        return ((Command<CalculatePrice>)request.Command).Payload;
    }
}