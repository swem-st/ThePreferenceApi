namespace ThePreference.Core.Application.DTO.CategoryModels;

public class CategoryDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public bool IsDeleted { get; set; }
}