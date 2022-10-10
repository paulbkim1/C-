using Microsoft.AspNetCore.Mvc;
using Products.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class ProductsController : Controller
{
    private MyContext db;
    public ProductsController(MyContext context)
    {
        db = context;
    }


    [HttpGet("")]
    public IActionResult ProductsPage()
    {
        List<Product> AllProducts = db.Products.ToList();

        return View("ProductsPage", AllProducts);
    }


    [HttpPost("products/add")]
    public IActionResult NewProduct(Product NewProduct)
    {
        db.Products.Add(NewProduct);
        db.SaveChanges();

        return RedirectToAction("ProductsPage");
    }
}