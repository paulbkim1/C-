using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DojoSurveywValidation.Models;

namespace DojoSurveywValidation.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        return View("Index");
    }

    [HttpPost("survey_data")]
    public IActionResult Data(Survey newinfo)
    {
        if (ModelState.IsValid)
        {
            HttpContext.Session.SetString("Name", newinfo.Name);
            HttpContext.Session.SetString("Location", newinfo.Location);
            HttpContext.Session.SetString("Language", newinfo.Language);
            if (newinfo.Comment == null)
            {
                HttpContext.Session.SetString("Comment", "");
            }
            else
            {
                HttpContext.Session.SetString("Comment", newinfo.Comment);
            }
            return Redirect("/submit");
        }
        else
        {
            return View("Index");
        }
    }

    [HttpGet("submit")]
    public IActionResult SurveyData()
    {
        return View("SurveyData");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
