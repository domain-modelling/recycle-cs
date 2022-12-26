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
    public Event Handle(IList<Event> events, Command command)
    {
        logger.Log(LogLevel.Information, "/handle-command succeeded");
        logger.Log(LogLevel.Information, "events " + events);
        logger.Log(LogLevel.Information, "command " + command);
        var response = PriceWasCalculated.Build("Tom", 0, "EUR");
        logger.Log(LogLevel.Information, "response " + response);
        return response;
    }
}
