using Microsoft.AspNetCore.Mvc;
using BankAccount.Models;
using Microsoft.AspNetCore.Identity;

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
    public IActionResult Homepage()
    {
        return View("Homepage");
    }


    [HttpPost("/user/register")]
    public IActionResult Register(User NewUser)
    {
        if (ModelState.IsValid)
        {
            if (db.Users.Any( i => i.Email == NewUser.Email))
            {
                ModelState.AddModelError("Email", "Email is already taken");
            }
        }

        if (ModelState.IsValid == false)
        {
            return Homepage();
        }

        PasswordHasher<User> passhash = new PasswordHasher<User>();
        NewUser.Password = passhash.HashPassword(NewUser, NewUser.Password);
        
        db.Users.Add(NewUser);
        db.SaveChanges();

        HttpContext.Session.SetInt32("UserId", NewUser.UserId);
        HttpContext.Session.SetString("UserName", NewUser.FirstName + " " + NewUser.LastName);

        return Redirect($"/accounts/{NewUser.UserId}");
    }


    [HttpPost("/user/login")]
    public IActionResult Login(LoginUser loginUser)
    {
        if (ModelState.IsValid == false)
        {
            return Homepage();
        }

        User? CurrentUser = db.Users.FirstOrDefault(i => i.Email == loginUser.LoginEmail);

        if (CurrentUser == null)
        {
            ModelState.AddModelError("LoginEmail", "Email/Password is not valid");
            return Homepage();
        }

        PasswordHasher<LoginUser> passhash = new PasswordHasher<LoginUser>();
        PasswordVerificationResult Comparepw = passhash.VerifyHashedPassword(loginUser, CurrentUser.Password, loginUser.LoginPassword);

        if (Comparepw == 0)
        {
            ModelState.AddModelError("LoginPassword", "Email/Password is not valid");
            return Homepage();
        }

        HttpContext.Session.SetInt32("UserId", CurrentUser.UserId);
        HttpContext.Session.SetString("UserName", CurrentUser.FirstName + " " + CurrentUser.LastName);
        return Redirect($"/accounts/{CurrentUser.UserId}");
    }
}