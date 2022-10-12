using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class WeddingsController : Controller
{
    private int? uid
    {
        get
        {
            return HttpContext.Session.GetInt32("UserId");
        }
    }

    private bool loggedIn
    {
        get
        {
            return uid != null;
        }
    }
    private MyContext db;
    public WeddingsController(MyContext context)
    {
        db = context;
    }


    [HttpGet("/weddings/{WeddingId}")]
    public IActionResult GuestList(int WeddingId)
    {
        if (!loggedIn || uid == null)
        {
            return RedirectToAction("Index", "Users");
        }

        Wedding? GuestList = db.Weddings.Include( i => i.Planner).Include( i => i.WeddingInvitations).ThenInclude( i => i.User).FirstOrDefault( i => i.WeddingId == WeddingId);
        return View("GuestList", GuestList);
    }


    [HttpGet("/weddings/new")]
    public IActionResult NewWedding()
    {
        if (!loggedIn || uid == null)
        {
            return RedirectToAction("Index", "Users");
        }

        return View("NewWedding");
    }


    [HttpPost("/weddings/add")]
    public IActionResult PlanWedding(Wedding planWedding)
    {
        if (!loggedIn || uid == null)
        {
            return RedirectToAction("Index", "Users");
        }

        if (planWedding.Date < DateTime.Now)
        {
            ModelState.AddModelError("Date", "Date must be in the future");
            return NewWedding();
        }

        planWedding.UserId = (int)uid;
        db.Weddings.Add(planWedding);
        db.SaveChanges();

        int WeddingId = planWedding.WeddingId;
        return Redirect($"/weddings/{WeddingId}");
    }
}