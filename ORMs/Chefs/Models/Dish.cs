using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Chefs.Models;
#pragma warning disable CS8618

public class Dish
{
    [Key]
    public int DishId { get; set; }


    [Required(ErrorMessage = "Name of dish is required")]
    [Display(Name = "Name of Dish")]
    public string Food { get; set; }


    [Required(ErrorMessage = "# of calories is required")]
    [Display(Name = "# of Calories")]
    [Range(1,10000000000, ErrorMessage ="# of calories must be greater than 0")]
    public int Calories { get; set; }


    [Required(ErrorMessage = "Chef's name is required")]
    [Display(Name = "Chef's Name")]
    public string ChefName { get; set; }


    [Required(ErrorMessage = "Tastiness is required")]
    [Display(Name = "Tastiness")]
    [Range(1,5, ErrorMessage ="Tastiness must be between 1-5")]
    public int Tastiness { get; set; }


    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;


    public int ChefId { get; set; }
    public Chef? UserChef { get; set; }
}