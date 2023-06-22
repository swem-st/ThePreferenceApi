namespace ThePreference.Core.Application.DTO.ColorModels;

public class ColorDTO
{
    public Guid Id { get; set; }
    public bool IsBasic { get; set; }
    public string Name { get; set; } = null!;
    public string Code { get; set; } = null!;
    public bool IsDeleted { get; set; }
}