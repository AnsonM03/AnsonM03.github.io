using System.ComponentModel.DataAnnotations;

namespace Portfolio.Api.Models;

public class Project
{
    public int Id { get; set; }

    [Required]
    [MaxLength(150)]
    public string Titel { get; set; } = string.Empty;

    [Required]
    public string Beschrijving { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string Categorie { get; set; } = string.Empty;

    [Required]
    [MaxLength(2048)]
    public string GitHubUrl { get; set; } = string.Empty;

    public DateTime Datum { get; set; }
}