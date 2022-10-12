using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class UsersController : Controller
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
    public UsersController(MyContext context)
    {
        db = context;
    }


    [HttpGet("/")]
    public IActionResult Index()
    {
        return View("Index");
    }


    [HttpPost("/register")]
    public IActionResult Register(User newUser)
    {
        if (ModelState.IsValid)
        {
            if (db.Users.Any(i => i.Email == newUser.Email))
            {
                ModelState.AddModelError("Email", "Email is already taken");
            }
        }

        if (ModelState.IsValid == false)
        {
            return Index();
        }

        PasswordHasher<User> passhash = new PasswordHasher<User>();
        newUser.Password = passhash.HashPassword(newUser, newUser.Password);

        db.Users.Add(newUser);
        db.SaveChanges();

        HttpContext.Session.SetInt32("UserId", newUser.UserId);
        return RedirectToAction("WeddingList");
    }


    [HttpPost("/login")]
    public IActionResult Login(LoginUser loginUser)
    {
        if (ModelState.IsValid == false)
        {
            return Index();
        }

        User? CurrentUser = db.Users.FirstOrDefault(i => i.Email == loginUser.LoginEmail);

        if (CurrentUser == null)
        {
            ModelState.AddModelError("LoginEmail", "Email/Password is not valid");
            return Index();
        }

        PasswordHasher<LoginUser> passhash = new PasswordHasher<LoginUser>();
        PasswordVerificationResult Comparepw = passhash.VerifyHashedPassword(loginUser, CurrentUser.Password, loginUser.LoginPassword);

        if (Comparepw == 0)
        {
            ModelState.AddModelError("LoginPassword", "Email/Password is not valid");
            return Index();
        }

        
        HttpContext.Session.SetInt32("UserId", CurrentUser.UserId);
        return RedirectToAction("WeddingList");
    }


    [HttpGet("/logout")]
    public IActionResult Logout()
    {
        if (!loggedIn || uid == null)
        {
            return RedirectToAction("Index");
        }

        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }


    [HttpGet("/weddings")]
    public IActionResult WeddingList()
    {
        if (!loggedIn || uid == null)
        {
            return RedirectToAction("Index");
        }

        int? UserId = (int)uid;
        User? UserName = db.Users.FirstOrDefault( i => i.UserId == UserId);
        HttpContext.Session.SetString("UserName", UserName.FirstName);

        List<Wedding> WeddingList = db.Weddings.Include( i => i.Planner).Include( i => i.WeddingInvitations).ThenInclude( i => i.User).ToList();
        return View("WeddingsList", WeddingList);
    }


    [HttpPost("/weddings/RSVP/{weddingId}")]
    public IActionResult RSVP(int weddingId)
    {
        if (!loggedIn || uid == null)
        {
            return RedirectToAction("Index");
        }

        UserWeddingInvitation? existingRSVP = db.UserWeddingInvitations.FirstOrDefault( i => i.WeddingId == weddingId && i.UserId == (int)uid);
        if (existingRSVP == null)
        {
            UserWeddingInvitation newRSVP = new UserWeddingInvitation()
            {
                UserId = (int)uid,
                WeddingId = weddingId
            };
            db.UserWeddingInvitations.Add(newRSVP);
        }
        else
        {
            db.UserWeddingInvitations.Remove(existingRSVP);
        }
        db.SaveChanges();
        return RedirectToAction("WeddingList");
    }
}
