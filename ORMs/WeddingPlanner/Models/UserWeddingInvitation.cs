using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WeddingPlanner.Models;
#pragma warning disable CS8618

public class UserWeddingInvitation
{
    [Key]
    public int UserWeddingInvitationId { get; set; }


    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;


    public int UserId { get; set; }
    public User? User { get; set; }
    public int WeddingId { get; set; }
    public Wedding? Wedding { get; set; }
}