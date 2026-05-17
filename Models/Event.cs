using System.ComponentModel.DataAnnotations;

namespace SecureMvcApp.Models;

public class Event
{
    

    public int Id { get; set; }
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be beween 3 and 100 caracteres")]
    [Display(Name = "Title")]
    public String? Title { get; set; }
    [Required(ErrorMessage = "veuillez saisir le lieu ")]
    [StringLength(250)]
    public String? Lieu { get; set; }
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime Date { get; set; } = DateTime.Now;

    [Range(1, int.MaxValue)]
    public int NombrePlaces { get; set; }
   public ICollection<Inscription> Inscriptions { get; set; }
        = new List<Inscription>();



}