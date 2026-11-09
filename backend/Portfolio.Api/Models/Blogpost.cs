using System.ComponentModel.DataAnnotations;

namespace Portfolio.Api.Models;

public class Blogpost
{
    public int Id { get; set; }

    [Required]
    [MaxLength(150)]
    public string Titel { get; set; } = string.Empty;

    [Required]
    public string Inhoud { get; set; } = string.Empty;

    public DateTime Publicatiedatum { get; set; }
}