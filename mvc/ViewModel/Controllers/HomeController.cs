using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ViewModel.Models;

namespace ViewModel.Controllers;

public class HomeController : Controller
{
    [HttpGet("")]
    public IActionResult home()
    {
        string message = "This is a messsage!";
        return View("Index", message);
    }

    [HttpGet("numbers")]
    public IActionResult numbers()
    {
        int[] arrayint = new int[] {1,3,5,7,8,12};
        return View("numbers", arrayint);
    }

    [HttpGet("users")]
    public IActionResult users()
    {
        List<string> users = new List<string>() 
        {
            "Anthony Ho",
            "Paul Kim",
            "Andrew Parker",
            "Justin Pham",
            "Jon Kim",
        };
        return View("users", users);
    }

    [HttpGet("user")]
    public IActionResult user()
    {
        string user = "Paul Kim";
        return View("user", user);
    }
}
