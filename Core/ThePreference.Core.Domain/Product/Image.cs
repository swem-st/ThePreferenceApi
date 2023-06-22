using CSharpFunctionalExtensions;

namespace ThePreference.Domain.Product;

public class Image
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public string ImageUrl { get; set; } = null!;
    public string? AltText { get; set; }
    
    private static string? ErrorMessage {get; set;}
    
    //Only for SUPERADMIN role
    public static Result<Image> CreateForExistProduct(Guid productId, string name, string? altText)
    {
        var result = new Image
        {
            ProductId = productId,
            ImageUrl = name,
            AltText = altText
        };
        
        var isValid = Validate(result) && ValidateProductId(result.ProductId);

        if (!isValid)
        { 
            return Result.Failure<Image>(ErrorMessage ?? "One or more validation errors occurred");
        }
        
        return Result.Success(result);
    }
    
    public static Result<Image> Create(string name, string? altText)
    {
        var result = new Image
        {
            ImageUrl = name,
            AltText = altText
        };
        
        var isValid = Validate(result);

        if (!isValid)
        { 
            return Result.Failure<Image>(ErrorMessage ?? "One or more validation errors occurred");
        }
        
        return Result.Success(result);
    }
    
    
    
    public static Result<Image> Update(Guid id, string name, string? altText)
    {
        var result = new Image
        {
            Id = id,
            ImageUrl = name,
            AltText = altText
        };
        
        var isValid = Validate(result, true);

        if (!isValid)
        { 
            return Result.Failure<Image>(ErrorMessage ?? "One or more validation errors occurred");
        }
        
        return Result.Success(result);
    }
    
    private static bool Validate(Image image, bool isUpdate = false)
    {
        if(isUpdate && image.Id == Guid.Empty)
        {
            ErrorMessage = $"{nameof(image.Id)} cannot be null or empty";
            return false;
        }
        
        if (String.IsNullOrWhiteSpace(image.ImageUrl))
        {
            ErrorMessage = $"{nameof(image.ImageUrl)} cannot be null or empty";
            return false;
        }
        
        if (image.ImageUrl.Length > 2048)
        {
            ErrorMessage = $"{nameof(image.ImageUrl)}: {image.ImageUrl} - cannot be more than 2048 characters";
            return false;
        }
        
        if (!String.IsNullOrWhiteSpace(image.AltText) && image.AltText.Length > 500)
        {
            ErrorMessage = $"{nameof(image.AltText)} cannot be more than 500 characters";
            return false;
        }
        
        return true;
    }
    
    private static bool ValidateProductId(Guid productId)
    {
        if (productId == Guid.Empty)
        {
            ErrorMessage = "Product ID cannot be null or empty";
            return false;
        }
        
        return true;
    }
}