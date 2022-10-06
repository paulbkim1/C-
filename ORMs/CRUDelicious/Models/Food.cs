using System.ComponentModel.DataAnnotations;

public class Food
{
    [Key]
    public int DishId { get; set; }


    [Display(Name = "Chef's Name")]
    [Required(ErrorMessage = "Chef name is required")]
    [DataType(DataType.Text)]
    public string Name { get; set; }


    [Display(Name = "Name of Dish")]
    [Required(ErrorMessage = "Dish name is required")]
    [DataType(DataType.Text)]
    public string Dish { get; set; }


    [Display(Name = "# of Calories")]
    [Required(ErrorMessage = "# of calories required")]
    [Range(0,5000000000000000000, ErrorMessage = "# of calories must be between at least 0")]
    public int Calories { get; set; }


    [Display(Name = "Tastiness")]
    [Required(ErrorMessage = "Tastiness Required")]
    [Range(1,5, ErrorMessage = "Tastiness must be between 1-5")]
    public int Tastiness { get; set; }


    [Display(Name = "Description")]
    [Required(ErrorMessage = "Description is required")]
    [DataType(DataType.Text)]
    public string Description { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

}