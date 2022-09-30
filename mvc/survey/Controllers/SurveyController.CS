using Microsoft.AspNetCore.Mvc;

public class SurveyController : Controller
{
    [HttpGet("")]
    public IActionResult survey()
    {
        return View("Index");
    }

    [HttpPost("survey_data")]
    public IActionResult survey_data(string name, string location, string language, string comment)
    {
        ViewBag.name = name;
        ViewBag.location = location;
        ViewBag.language = language;
        ViewBag.comment = comment;
        return View("result");
    }

}