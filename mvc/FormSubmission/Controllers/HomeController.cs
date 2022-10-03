using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FormSubmission.Models;

namespace FormSubmission.Controllers;

public class HomeController : Controller
{
    [HttpGet("")]
    public IActionResult Index()
    {
        return View("Index");
    }

    [HttpPost("FormData")]
    public IActionResult Submit(Form formdata)
    {
        if (ModelState.IsValid)
        {
            return RedirectToAction("Success");
        }
        else
        {
            return View("Index");
        }
    }

    [HttpGet("Success")]
    public IActionResult Success()
    {
        return View("Success");
    }
}
