using Microsoft.AspNetCore.Mvc;
using Recycle.WebAPI.Messages;

namespace Recycle.WebAPI.Controllers;

[Route("/handle-command")]
public partial class HandlingController
{
    private readonly ILogger<HandlingController> logger;
    private readonly CommandHandler commandHandler;

    public HandlingController(ILogger<HandlingController> logger)
    {
        this.logger = logger;
        commandHandler = new CommandHandler();
    }

    [HttpPost]
    public Event Handle(IList<Event> events, Command command)
    {
        logger.Log(LogLevel.Information, "/handle-command succeeded");
        logger.Log(LogLevel.Information, "events " + events);
        logger.Log(LogLevel.Information, "command " + command);
        var response = commandHandler.Handle(events, command);
        logger.Log(LogLevel.Information, "response " + response);
        return response;
    }
}
