using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Login.Models;

public class User
{
    [Key]
    public int UserId { get; set; }


    [Required(ErrorMessage = "First name is required")]
    [Display(Name = "First Name: ")]
    [MinLength(2, ErrorMessage = "First name must be at least 2 characters")]
    public string FirstName { get; set; }


    [Required(ErrorMessage = "Last name is required")]
    [Display(Name = "Last Name: ")]
    [MinLength(2, ErrorMessage = "Last name must be at least 2 characters")]
    public string LastName { get; set; }


    [Required(ErrorMessage = "Email is required")]
    [Display(Name = "Email: ")]
    [DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid email")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [Display(Name = "Password: ")]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
    [DataType(DataType.Password)]
    public string Password { get; set; }


    [NotMapped]
    [Required(ErrorMessage = "Password is required")]
    [Display(Name = "Confirm Password: ")]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Passwords do not match")]
    public string ConfirmPass { get; set; }


    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}