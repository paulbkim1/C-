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


    [HttpGet("/")]
    public IActionResult ProductsPage()
    {
        List<Product> AllProducts = db.Products.ToList();

        return View("ProductsPage", AllProducts);
    }


    [HttpPost("/products/add")]
    public IActionResult NewProduct(Product NewProduct)
    {
        db.Products.Add(NewProduct);
        db.SaveChanges();

        return RedirectToAction("ProductsPage");
    }


    [HttpGet("/products/{productId}")]
    public IActionResult ProductsPage(int productId)
    {
        Product ProductName = db.Products.FirstOrDefault(i => i.ProductId == productId);
        ViewBag.ProductName = ProductName;

        List<Category> CategoryList = db.Categorys.ToList();
        ViewBag.CategoryList = CategoryList;

        Product? ProductCategorys = db.Products.Include( i => i.ProductAssocations).ThenInclude( i => i.Category).FirstOrDefault( i => i.ProductId == productId);

        return View("AddCategory", ProductCategorys);
    }


    [HttpPost("/products/category/{productId}")]
    public IActionResult AddProductCategory(ProductCategoryAssociation NewProductCategory, int productId)
    {
        ProductCategoryAssociation NewAssociation = new ProductCategoryAssociation()
        {
            ProductId = productId,
            CategoryId = NewProductCategory.CategoryId
        };

        db.ProductCategoryAssociations.Add(NewAssociation);
        db.SaveChanges();

        return RedirectToAction("ProductsPage");
    }
}