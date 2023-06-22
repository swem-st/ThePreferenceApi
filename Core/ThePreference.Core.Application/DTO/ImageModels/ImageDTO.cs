namespace ThePreference.Core.Application.DTO.ImageModels;

public class ImageDTO
{
    public Guid Id { get; set; }
    public string ImageUrl { get; set; } = null!;
    public string? AltText { get; set; }
}