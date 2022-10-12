using Microsoft.AspNetCore.Mvc;
using Chefs.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class ChefsController : Controller
{
    private MyContext db;
    public ChefsController(MyContext context)
    {
        db = context;
    }


    [HttpGet("/")]
    public IActionResult ChefList()
    {
        List<Chef> AllChefs = db.Chefs.Include( c => c.ChefDishs).ToList();
        
        return View("ChefList", AllChefs);
    }


    [HttpGet("/chefs/new")]
    public IActionResult ChefAdd()
    {
        return View("ChefAdd");
    }


    [HttpPost("/chef/add")]
    public IActionResult AddChef(Chef NewChef)
    {
        if (ModelState.IsValid == false)
        {
            return ChefAdd();
        }
        db.Chefs.Add(NewChef);
        db.SaveChanges();
        return RedirectToAction("Cheflist");
    }
}