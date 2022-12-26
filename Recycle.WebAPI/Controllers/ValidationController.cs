using Microsoft.AspNetCore.Mvc;

namespace Recycle.WebAPI.Controllers;

[Route("/validate")]
public class ValidationController
{
    private readonly ILogger<WeatherForecastController> logger;

    public ValidationController(ILogger<WeatherForecastController> logger)
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