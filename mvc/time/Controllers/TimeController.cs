using Microsoft.AspNetCore.Mvc;

public class TimeController : Controller
{
    [HttpGet("")]
    public IActionResult Time()
    {
        DateTime CurrentTime = DateTime.Now;
        ViewBag.date = CurrentTime.ToString("MMM dd, yyyy");
        ViewBag.time = CurrentTime.ToString("h:mm tt");
        return View("Index");
    }
}