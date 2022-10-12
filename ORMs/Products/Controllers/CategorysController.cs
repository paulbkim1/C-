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


    [HttpGet("/categories")]
    public IActionResult CategorysPage()
    {
        List<Category> AllCategories = db.Categorys.ToList();

        return View("CategorysPage", AllCategories);
    }


    [HttpPost("/categories/add")]
    public IActionResult NewCategory(Category NewCategory)
    {

        db.Categorys.Add(NewCategory);
        db.SaveChanges();

        return RedirectToAction("CategorysPage");
    }


    [HttpGet("/categories/{categoryId}")]
    public IActionResult CategorysPage(int categoryId)
    {
        Category CategoryName = db.Categorys.FirstOrDefault(i => i.CategoryId == categoryId);
        ViewBag.CategoryName = CategoryName;

        List<Product> ProductList = db.Products.ToList();
        ViewBag.ProductList = ProductList;

        Category? CategoryProducts = db.Categorys.Include( i => i.CategoryAssociations).ThenInclude( i => i.Product).FirstOrDefault( i => i.CategoryId == categoryId);

        return View("AddProduct", CategoryProducts);
    }


    [HttpPost("/categories/product/{categoryId}")]
    public IActionResult AddCategoryProduct(ProductCategoryAssociation NewCategoryProduct, int categoryId)
    {
        ProductCategoryAssociation NewAssociation = new ProductCategoryAssociation()
        {
            ProductId = NewCategoryProduct.ProductId,
            CategoryId = categoryId
        };

        db.ProductCategoryAssociations.Add(NewAssociation);
        db.SaveChanges();

        return RedirectToAction("CategorysPage");
    }
}