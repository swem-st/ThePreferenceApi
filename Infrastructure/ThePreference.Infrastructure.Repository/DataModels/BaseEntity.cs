namespace ThePreference.Infrastructure.Repository.DataModels;

public class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public bool IsDeleted { get; set; }
    
    //For future use if we need to track who created/updated/deleted a record. When we will add user management.
    
    // [Required]
    // public string CreatedBy { get; set; }
    // [Required]
    // public string UpdatedBy { get; set; }
    // public string DeletedBy { get; set; }
    
    //also consider to implement Concurrency control and row versioning in the future.
}