namespace ThePreference.Domain.Product;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public Guid CategoryId { get; set; }
    public Guid BrandId { get; set; }
    public Model Model { get; set; }
    public ICollection<string> Images { get; set; }
    public ICollection<string> Colors { get; set; }

    public Product()
    {
        
    }

    public static Product Create(
        Guid id,
        string name,
        string title,
        string? description, 
        decimal price,
        Guid categoryId,
        Guid brandId,
        ICollection<string> images,
        ICollection<string> colors)
    {
        return new Product
        {
            Id = id,
            Name = name,
            Title = title,
            Description = description,
            Price = price,
            CategoryId = categoryId,
            BrandId = brandId,
            Images = images,
            Colors = colors
        };
    } 
}