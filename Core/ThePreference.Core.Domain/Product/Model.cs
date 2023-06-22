using CSharpFunctionalExtensions;

namespace ThePreference.Domain.Product;

public class Model
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    
    private static string? ErrorMessage {get; set;}
    
    public static Result<Model> Create(string name)
    {
        var result = new Model
        {
            Name = name.ToLower().Trim()
        };
        
        var isValid = Validate(result);

        if (!isValid)
        { 
            return Result.Failure<Model>(ErrorMessage ?? "One or more validation errors occurred");
        }
        
        return Result.Success(result);
    }
    
    private static bool Validate(Model model)
    {
        if (String.IsNullOrWhiteSpace(model.Name))
        {
            ErrorMessage = $"{nameof(model.Name)} cannot be null or empty";
            return false;
        }
        
        if (model.Name.Length > 100)
        {
            ErrorMessage = $"{nameof(model.Name)} cannot be more than 100 characters";
            return false;
        }
        
        return true;
    }
}