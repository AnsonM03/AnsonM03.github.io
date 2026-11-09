using System.ComponentModel.DataAnnotations;

namespace Portfolio.Api.Dtos;

public class BlogpostInputDto
{
    [Required]
    [MaxLength(150)]
    public string Titel { get; set; } = string.Empty;

    [Required]
    public string Inhoud { get; set; } = string.Empty;

    [Required]
    public DateTime? Publicatiedatum { get; set; }
}