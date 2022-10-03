using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Passcode.Models;

namespace Passcode.Controllers;

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
        int count = 0;
        HttpContext.Session.SetInt32("Count", count);
        return View("Index");
    }

    [HttpPost("generate")]
    public IActionResult Create()
    {
        Random rand = new Random();
        string str = "abcdefghijklmnopqrstuvwxyz";
        string newStr = "";
        for (int i = 0; i < 14; i++)
        {
            int randNum = rand.Next(26);
            newStr = newStr + str[randNum];
        }

        int? currentCount = HttpContext.Session.GetInt32("Count");
        currentCount = currentCount + 1;
        HttpContext.Session.SetInt32("Count", currentCount);
        return RedirectToAction("");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
