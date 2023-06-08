namespace ThePreference.Infrastructure.Repository.DataModels.Product;

public class ProductColorEntity
{
    public Guid ProductId { get; set; }
    public ProductEntity Product { get; set; } = null!;

    public Guid ColorId { get; set; }
    public ColorEntity Color { get; set; } = null!;
}