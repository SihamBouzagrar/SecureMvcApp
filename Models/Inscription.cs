using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace SecureMvcApp.Models;

public class Inscription
{
    public int Id { get; set; }

    [Required]
    public string UserId { get; set; } = string.Empty;

    public IdentityUser? User { get; set; }

    [Required]
    public int EventId { get; set; }

    public Event? Event { get; set; }

    public DateTime DateInscription { get; set; } = DateTime.Now;
}