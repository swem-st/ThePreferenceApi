using CSharpFunctionalExtensions;

namespace ThePreference.Domain.Product;

public class Brand
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;

    public bool IsDeleted { get; set; }

    private static string? ErrorMessage {get; set;}
    
    public static Result<Brand> Create(string name)
    {
        var result = new Brand
        {
            Name = name.ToLower().Trim()
        };
        
        var isValid = Validate(result);

        if (!isValid)
        { 
            return Result.Failure<Brand>(ErrorMessage ?? "One or more validation errors occurred");
        }
        
        return Result.Success(result);
    }
    
    public static Result<Brand> Update(Guid id, string name)
    {
        var result = new Brand
        {
            Id = id,
            Name = name.ToLower().Trim()
        };
        
        var isValid = Validate(result, true);

        if (!isValid)
        { 
            return Result.Failure<Brand>(ErrorMessage ?? "One or more validation errors occurred");
        }
        
        return Result.Success(result);
    }
    
    private static bool Validate(Brand brand, bool isUpdate = false)
    {
        if(isUpdate && brand.Id == Guid.Empty)
        {
            ErrorMessage = $"{nameof(brand.Id)} cannot be null or empty";
            return false;
        }
        
        if (String.IsNullOrWhiteSpace(brand.Name))
        {
            ErrorMessage = $"{nameof(brand.Name)} cannot be null or empty";
            return false;
        }
        
        if (brand.Name.Length > 100)
        {
            ErrorMessage = $"{nameof(brand.Name)} cannot be more than 100 characters";
            return false;
        }
        
        return true;
    }
}