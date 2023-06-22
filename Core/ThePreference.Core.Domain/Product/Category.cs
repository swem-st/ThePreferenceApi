using CSharpFunctionalExtensions;

namespace ThePreference.Domain.Product;

public class Category
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public bool IsDeleted { get; set; }
    
    private static string? ErrorMessage {get; set;}
    
    public static Result<Category> Create(string name)
    {
        var result = new Category
        {
            Name = name.ToLower().Trim()
        };
        
        var isValid = Validate(result);

        if (!isValid)
        { 
            return Result.Failure<Category>(ErrorMessage ?? "One or more validation errors occurred");
        }
        
        return Result.Success(result);
    }
    
    public static Result<Category> Update(Guid id, string name)
    {
        var result = new Category
        {
            Id = id,
            Name = name.ToLower().Trim()
        };
        
        var isValid = Validate(result, true);

        if (!isValid)
        { 
            return Result.Failure<Category>(ErrorMessage ?? "One or more validation errors occurred");
        }
        
        return Result.Success(result);
    }
    
    private static bool Validate(Category category, bool isUpdate = false)
    {
        if (isUpdate && category.Id == Guid.Empty)
        { 
            ErrorMessage = $"{nameof(category.Id)} cannot be empty";
            return false;
        }
        
        if (String.IsNullOrWhiteSpace(category.Name))
        {
            ErrorMessage = $"{nameof(category.Name)} cannot be null or empty";
            return false;
        }
        
        if (category.Name.Length > 100)
        {
            ErrorMessage = $"{nameof(category.Name)} cannot be more than 100 characters";
            return false;
        }
        
        return true;
    }
}