using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ViewModel.Models;

namespace ViewModel.Controllers;

public class HomeController : Controller
{
    [HttpGet("")]
    public IActionResult home()
    {
        return View("Index");
    }

    [HttpGet("numbers")]
    public IActionResult numbers()
    {
        return View("numbers");
    }

    [HttpGet("users")]
    public IActionResult users()
    {
        return View("users");
    }

    [HttpGet("user")]
    public IActionResult user()
    {
        return View("user");
    }
}
