using CSharpFunctionalExtensions;

namespace ThePreference.Domain.Product;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Title { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    
    public Brand Brand { get; set; } = null!;
    public Model? Model { get; set; }
    
    //For now, we gonna completely remove(just relations with product) all categories and add new ones, as we don't have a lot of categories and it's not a big deal to remove them and add new ones. Maybe in the future, we will change this logic.
    public ICollection<Category> Categories { get; set; } = null!;
    public bool IsCategoriesHaveChanged { get; set; }
    
    //We will only add images to the product, we will not delete them, for deleting we will call another endpoint(at Frontend) and will remove them completely from the DB
    public ICollection<Image> Images { get; set; } = null!;
    
    public ICollection<Color> Colors { get; set; } = null!;
    
    public bool IsUpdate { get; set; }
    
    //DeletedColors property represent the colors where we gonna remove any relations with product, colors still will be in the DB!
    public ICollection<Guid> DeletedColors { get; set; } = null!;
    
    private static string? ErrorMessage {get; set;}

    public static Result<Product> Create(
        string name,
        string title,
        string? description, 
        decimal price,
        string? modelName,
        ICollection<Category> categories,
        ICollection<Image> images,
        ICollection<Color> colors)
    {
        var result = new Product
        {
            Name = name.ToLower().Trim(),
            Title = title,
            Description = description,
            Price = price,
            Categories = categories,
            Images = images,
            Colors = colors,
            IsCategoriesHaveChanged = true
        };
        
        if (!String.IsNullOrWhiteSpace(modelName))
        {
            var model = Model.Create(modelName);
            if (model.IsFailure)
            {
                return Result.Failure<Product>(model.Error);
            }
            
            result.Model = model.Value;
        }
        
        var isValid = Validate(result);
        
        if (!isValid)
        { 
            return Result.Failure<Product>(ErrorMessage ?? "One or more validation errors occurred");
        }
        
        return Result.Success(result);
    }
    
    public static Result<Product> Update(
        Guid id,
        string name,
        string title,
        string? description, 
        decimal price,
        string? modelName,
        ICollection<Category> categories,
        bool isCategoriesHaveChanged,
        ICollection<Guid>? deletedColors)
    {
        var result = new Product
        {
            Id = id,
            Name = name.ToLower().Trim(),
            Title = title,
            Description = description,
            Price = price,
            Categories = categories,
            IsCategoriesHaveChanged = isCategoriesHaveChanged,
            Images = new List<Image>(),
            Colors = new List<Color>(),
            DeletedColors = deletedColors ?? new List<Guid>(),
            IsUpdate = true
        };
        
        if (!String.IsNullOrWhiteSpace(modelName))
        {
            var model = Model.Create(modelName);
            if (model.IsFailure)
            {
                return Result.Failure<Product>(model.Error);
            }
            
            result.Model = model.Value;
        }
        
        var isValid = Validate(result, true);

        if (!isValid)
        { 
            return Result.Failure<Product>(ErrorMessage ?? "One or more validation errors occurred");
        }
        
        return Result.Success(result);
    }

    private static bool Validate(Product product, bool isUpdate = false)
    {
        if (String.IsNullOrWhiteSpace(product.Name))
        {
            ErrorMessage = $"{nameof(product.Name)} cannot be null or empty";
            return false;
        }
        
        if (product.Name.Length > 200)
        {
            ErrorMessage = $"{nameof(product.Name)} cannot be more than 200 characters";
            return false;
        }

        if (!String.IsNullOrWhiteSpace(product.Title) && product.Title.Length > 500)
        {
            ErrorMessage = $"{nameof(product.Title)} cannot be more than 500 characters";
            return false;
        }
        
        if (!String.IsNullOrWhiteSpace(product.Description) && product.Description.Length > 500)
        {
            ErrorMessage = $"{nameof(product.Description)} cannot be more than 500 characters";
            return false;
        }
        
        if (product.Price <= 0 || product.Price > 1_000_000_000)
        {
            ErrorMessage = $"{nameof(product.Price)} out off range. Number cannot be less than or equal to zero and greater than 1 billion";
            return false;
        }
        
        var isValid = isUpdate ? ValidateUpdate(product) : ValidateCreate(product);
        
        return isValid;
    }

    private static bool ValidateCreate(Product product)
    {
        if (product.Categories.Count == 0)
        {
            ErrorMessage = $"{nameof(product.Categories)} cannot be null or empty";
            return false;
        }

        if (product.Images.Count == 0)
        {
            ErrorMessage = $"{nameof(product.Images)} cannot be null or empty";
            return false;
        }

        if (product.Colors.Count == 0)
        {
            ErrorMessage = $"{nameof(product.Colors)} cannot be null or empty";
            return false;
        }

        return true;
    }

    private static bool ValidateUpdate(Product product)
    {
        if(product.Id == Guid.Empty)
        {
            ErrorMessage = $"{nameof(product.Id)} cannot be null or empty";
            return false;
        }

        if (product is { IsCategoriesHaveChanged: true, Categories.Count: 0 })
        {
            ErrorMessage = $"{nameof(product.Categories)} cannot be null or empty";
            return false;
        }

        return true;
    }
}