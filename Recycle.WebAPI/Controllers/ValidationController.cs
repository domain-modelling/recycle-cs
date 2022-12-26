using Microsoft.AspNetCore.Mvc;

namespace Recycle.WebAPI.Controllers;

[Route("/validate")]
public class ValidationController
{
    private readonly ILogger<ValidationController> logger;

    public ValidationController(ILogger<ValidationController> logger)
    {
        this.logger = logger;
    }

    [HttpGet]
    public ActionResult Index()
    {
        logger.Log(LogLevel.Information, "/validate succeeded");
        return new OkResult();
    }
}