using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThePreference.Infrastructure.Repository.DataModels.User;

public class AddressEntity
{
    public Guid Id { get; set; }
    
    [Required]
    [MaxLength(200)]
    public string Country { get; set; }
    
    [Required]
    [MaxLength(500)]
    public string AddressLineOne { get; set; }
    
    [MaxLength(500)]
    public string AddressLineTwo { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string City { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string State { get; set; }
    
    [Required]
    [MaxLength(20)]
    [Column(TypeName = "varchar(20)")]
    public string PhoneNumber { get; set; }
    
    [Required]
    [MaxLength(50)]
    [Column(TypeName = "varchar(50)")]
    public string PostCode { get; set; }
    
    public Guid UserId { get; set; }
    public UserEntity UserEntity { get; set; }
}