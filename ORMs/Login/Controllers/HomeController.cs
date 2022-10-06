using Microsoft.AspNetCore.Mvc;
using Login.Models;
using Microsoft.AspNetCore.Identity;

public class HomeController : Controller
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
    public HomeController(MyContext context)
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
        return RedirectToAction("Success");
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
        return RedirectToAction("Success");
    }


    [HttpGet("/success")]
    public IActionResult Success()
    {
        if(!loggedIn)
        {
            return RedirectToAction("Index");
        }
        return View("Success");
    }


    [HttpPost("/logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }
}
