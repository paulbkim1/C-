using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    [HttpGet("")]
    public IActionResult Home()
    {
        return View("Home");
    }

    [HttpGet("projects")]
    public IActionResult Projects()
    {
        return View("Projects");
    }

    [HttpGet("contact")]
    public IActionResult Contact()
    {
        return View("Contact");
    }
}
