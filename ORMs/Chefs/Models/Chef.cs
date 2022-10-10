using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Chefs.Models;
#pragma warning disable CS8618

public class Chef
{
    [Key]
    public int ChefId { get; set; }


    [Required(ErrorMessage = "First name is required")]
    [Display(Name = "First Name: ")]
    public string FirstName { get; set; }


    [Required(ErrorMessage = "Last name is required")]
    [Display(Name = "Last Name: ")]
    public string LastName { get; set; }


    [Required(ErrorMessage = "Date of Birth is required")]
    [Display(Name = "Date of Birth: ")]
    [DataType(DataType.Date)]
    public DateTime DoB { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;


    public List<Dish> ChefDishs { get; set; } = new List<Dish>();
}