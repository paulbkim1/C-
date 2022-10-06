using CRUDelicious.Models;
using Microsoft.AspNetCore.Mvc;

public class FoodsController : Controller
{
    private MyContext db;
    public FoodsController(MyContext context)
    {
        db = context;
    }


    [HttpGet("/")]
    public IActionResult Index()
    {
        List<Food> allFoods = db.Foods.ToList();
        return View("Index", allFoods);
    }


    [HttpGet("dishes/new")]
    public IActionResult New()
    {
        return View("New");
    }

    [HttpPost("dishes/create")]
    public IActionResult Create(Food newFood)
    {
        if(!ModelState.IsValid)
        {
            return New();
        }

        db.Foods.Add(newFood);
        db.SaveChanges();

        return RedirectToAction("Index");
    }

    [HttpGet("/dishes/{oneDishId}")]
    public IActionResult View(int oneDishId)
    {
        Food? food = db.Foods.FirstOrDefault( i => i.DishId == oneDishId);
        if (food == null)
        {
            return RedirectToAction("Index");
        }
        return View("Info", food);
    }

    [HttpPost("/dishes/{deleteDishId}/delete")]
    public IActionResult Delete(int deleteDishId)
    {
        Food? food = db.Foods.FirstOrDefault( i => i.DishId == deleteDishId);
        if (food != null)
        {
            db.Foods.Remove(food);
            db.SaveChanges();
        }
        return RedirectToAction("Index");
    }

    [HttpGet("/dishes/{dishId}/edit")]
    public IActionResult Edit(int dishId)
    {
        Food? food = db.Foods.FirstOrDefault( i => i.DishId == dishId);
        if (food == null)
        {
            return RedirectToAction("Index");
        }
        return View("Edit", food);
    }

    [HttpPost("/dishes/{dishId}/update")]
    public IActionResult Update(Food editFood, int dishId)
    {
        if (ModelState.IsValid == false)
        {
            return Edit(dishId);
        }
        Food? food = db.Foods.FirstOrDefault( i => i.DishId == dishId);

        if (food == null)
        {
            return RedirectToAction("Index");
        }

        food.Name = editFood.Name;
        food.Dish = editFood.Dish;
        food.Calories = editFood.Calories;
        food.Tastiness = editFood.Tastiness;
        food.Description = editFood.Description;

        db.Foods.Update(food);
        db.SaveChanges();

        return Redirect($"/dishes/{food.DishId}");
    }
}