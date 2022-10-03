using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using dojo_survey.Models;

namespace dojo_survey.Controllers;

public class HomeController : Controller
{
    [HttpGet("")]
    public IActionResult survey()
    {
        return View("Index");
    }

    [HttpPost("survey_data")]
    public IActionResult survey_data(Survey yourSurvey)
    {
        return View("results", yourSurvey);
    }
}
