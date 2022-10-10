using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Products.Models;
#pragma warning disable CS8618

public class Category
{
    [Key]
    public int CategoryId { get; set; }


    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }


    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;


    public int ProductId { get; set; }
    public Product? Item { get; set; }

    public List<ProductCategoryAssociation> CategoryAssociations { get; set; } = new List<ProductCategoryAssociation>();

}