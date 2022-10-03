using System.ComponentModel.DataAnnotations;

public class Form
{
    [Required(ErrorMessage = "Is required")]
    [MinLength(4, ErrorMessage = "Must be at least 4 characters")]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Is required")]
    [MinLength(4, ErrorMessage = "Must be at least 4 characters")]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Is required")]
    [Range(1,200)]
    public int Age { get; set; }

    [Required(ErrorMessage = "Is required")]
    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email Address")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Is required")]
    [MinLength(8, ErrorMessage = "Must be at least 8 characters")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}