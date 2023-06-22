using CSharpFunctionalExtensions;

namespace ThePreference.Domain.Product;

public class Color
{
    public Guid Id { get; set; }

    public bool IsBasic { get; set; }
    public string Name { get; set; } = null!;
    public string Code { get; set; } = null!;
    public bool IsDeleted { get; set; }
    
    private static string? ErrorMessage {get; set;}
    
    public static Result<Color> Create(bool isBasic, string name, string code)
    {
        var result = new Color
        {
            IsBasic = isBasic,
            Name = name.ToLower().Trim(),
            Code = code.ToLower().Trim(), 
        };
        
        var isValid = Validate(result);

        if (!isValid)
        { 
            return Result.Failure<Color>(ErrorMessage ?? "One or more validation errors occurred");
        }
        
        return Result.Success(result);
    }
    
    public static Result<Color> Update(Guid id, bool isBasic, string name, string code)
    {
        var result = new Color
        {
            Id = id,
            IsBasic = isBasic,
            Name = name.ToLower().Trim(),
            Code = code.ToLower().Trim()
        };
        
        var isValid = Validate(result, true);

        if (!isValid)
        { 
            return Result.Failure<Color>(ErrorMessage ?? "One or more validation errors occurred");
        }
        
        return Result.Success(result);
    }
    
    private static bool Validate(Color color, bool isUpdate = false)
    {
        if(isUpdate && color.Id == Guid.Empty)
        {
            ErrorMessage = $"{nameof(color.Id)} cannot be null or empty";
            return false;
        }
        
        if (String.IsNullOrWhiteSpace(color.Name))
        {
            ErrorMessage = $"{nameof(color.Name)} cannot be null or empty";
            return false;
        }
        
        if (color.Name.Length > 255)
        {
            ErrorMessage = $"{nameof(color.Name)} cannot be more than 255 characters";
            return false;
        }
        
        if (color.Code.Length != 6)
        {
            ErrorMessage = $"{nameof(color.Code)} must be exactly 6 characters long.";
            return false;
        }
        
        return true;
    }
}