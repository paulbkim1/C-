using Microsoft.AspNetCore.Mvc;
using Chefs.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class DishsController : Controller
{
    private MyContext db;
    public DishsController(MyContext context)
    {
        db = context;
    }


    [HttpGet("/dishes")]
    public IActionResult DishList()
    {
        List<Dish> AllDishs = db.Dishs.Include( i => i.UserChef).ToList();
        return View("DishList", AllDishs);
    }


    [HttpGet("/dishes/new")]
    public IActionResult DishAdd()
    {
        return View("DishAdd");
    }


    [HttpPost("/dishes/add")]
    public IActionResult NewDish(Dish NewDish)
    {
        if (ModelState.IsValid == false)
        {
            return DishAdd();
        }
        NewDish.ChefId = 1;
        db.Dishs.Add(NewDish);
        db.SaveChanges();
        return RedirectToAction("DishList");
    }
}