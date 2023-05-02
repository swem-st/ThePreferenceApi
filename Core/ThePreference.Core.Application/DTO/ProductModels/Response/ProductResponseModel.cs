namespace ThePreference.Application.DTO.ProductModels.Response;

public class ProductResponseModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public Guid CategoryId { get; set; }
    public string CategoryName { get; set; }
    public Guid BrandId { get; set; }
    public string BrandName { get; set; }
    public ModelResponseModel Model { get; set; }
    public ICollection<string> Images { get; set; }
    public ICollection<string> Colors { get; set; }
}