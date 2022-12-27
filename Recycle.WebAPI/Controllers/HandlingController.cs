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
    public Event Handle()
    {
        var response = commandHandler.Handle();
        logger.Log(LogLevel.Information, "/handle-command => " + response);
        return response;
    }
}