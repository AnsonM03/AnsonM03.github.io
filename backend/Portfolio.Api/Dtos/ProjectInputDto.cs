using System.ComponentModel.DataAnnotations;

namespace Portfolio.Api.Dtos;

public class ProjectInputDto
{
    [Required]
    [MaxLength(150)]
    public string Titel { get; set; } = string.Empty;

    [Required]
    public string Beschrijving { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string Categorie { get; set; } = string.Empty;

    [Required]
    [Url]
    [MaxLength(2048)]
    public string GitHubUrl { get; set; } = string.Empty;

    [Required]
    public DateTime? Datum { get; set; }
}