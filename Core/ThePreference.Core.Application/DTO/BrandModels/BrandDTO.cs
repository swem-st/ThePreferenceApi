namespace ThePreference.Core.Application.DTO.BrandModels;

public class BrandDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public bool IsDeleted { get; set; }
}