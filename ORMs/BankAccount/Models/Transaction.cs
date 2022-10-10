using System.ComponentModel.DataAnnotations;
namespace BankAccount.Models;
#pragma warning disable CS8618


public class Transaction
{
    [Key]
    public int TransactionId { get; set; }

    [Required(ErrorMessage = "Amount is required")]
    [Range(-10000000000,10000000000)]
    public decimal Amount { get; set; }


    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public int UserId { get; set; }
    public User? Customer { get; set; }
}