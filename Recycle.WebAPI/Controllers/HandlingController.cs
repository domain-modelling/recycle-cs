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
    public IActionResult Handle([FromBody] RecycleRequest request)
    {
        Event response = new Event<PriceWasCalculated>
        {
            EventId = Guid.NewGuid().ToString(),
            CreatedAt = DateTime.Now,
            Payload = new PriceWasCalculated { CardId = "123", PriceAmount = 0, PriceCurrency = "EUR" }
        };
        return new OkObjectResult(response);
    }
}