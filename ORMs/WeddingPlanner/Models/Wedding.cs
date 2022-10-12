using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WeddingPlanner.Models;

public class Wedding
{
    [Key]
    public int WeddingId { get; set; }


    [Required(ErrorMessage = "Wedder One is required")]
    [Display(Name = "Wedder One: ")]
    public string WedderOne { get; set; }


    [Required(ErrorMessage = "Wedder Two is required")]
    [Display(Name = "Wedder Two: ")]
    public string WedderTwo { get; set; }


    [Required(ErrorMessage = "Date is required")]
    [Display(Name = "Date: ")]
    [DataType(DataType.Date)]
    public DateTime Date { get; set; }

    [Required(ErrorMessage = "Address is required")]
    [Display(Name = "Address: ")]
    [DataType(DataType.Password)]
    public string Address { get; set; }


    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public int UserId { get; set; }
    public User? Planner { get; set; }
    public List<UserWeddingInvitation> WeddingInvitations { get; set; } = new List<UserWeddingInvitation>();
}