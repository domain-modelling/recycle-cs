using Microsoft.AspNetCore.Mvc;

namespace Recycle.WebAPI.Controllers;

[Route("/")]
public class ValidationController : ControllerBase
{
    private readonly ILogger<ValidationController> logger;

    public ValidationController(ILogger<ValidationController> logger)
    {
        this.logger = logger;
    }

    [HttpGet]
    public IActionResult Home()
    {
        return Content(
            "{ " +
            "\"message\":" +
            "\"please enter a public URL to this site on https://domainmodelling.dev, as specified in the readme\"" +
            "}"
        );
    }

    [HttpGet("/validate")]
    public ActionResult Index()
    {
        return new OkResult();
    }
}