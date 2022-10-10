using Microsoft.AspNetCore.Mvc;
using Products.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class CategorysController : Controller
{
    private MyContext db;
    public CategorysController(MyContext context)
    {
        db = context;
    }
}