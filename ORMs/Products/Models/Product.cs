using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Products.Models;
#pragma warning disable CS8618

public class Product
{
    [Key]
    public int ProductId { get; set; }


    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }


    [Required(ErrorMessage = "Description is required")]
    [DataType(DataType.Text)]
    public string Description { get; set; }


    [Required(ErrorMessage = "Price is required")]
    [Range(0,100000000)]
    public decimal Price { get; set; }


    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;


    public List<Category> ProductCategorys { get; set; } = new List<Category>();
    public List<ProductCategoryAssociation> ProductAssocations { get; set; } = new List<ProductCategoryAssociation>();
}