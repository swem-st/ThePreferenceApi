using System.ComponentModel.DataAnnotations;

namespace ThePreference.Infrastructure.Repository.DataModels.User;

public class UserEntity
{
        public Guid Id { get; set; }

        [MaxLength(500)]
        public string FirstName { get; set; }

        [MaxLength(500)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(128)]
        public string Password { get; set; }
        
        [Required]
        [MaxLength(128)]
        public string Email { get; set; }
        
        public int Age { get; set; }
        
        public ICollection<AddressEntity> Address { get; set; }
        
        [MaxLength(128)]
        public string Token { get; set; }
        
        public bool? IsActive { get; set; }
        
        public bool? IsDeleted { get; set; }
        
        //maybe we gonna need this later
        //public List<Payment> Payment { get; set; }
        // public int AccountID { get; set; }
        // public int? PermissionRoleID { get; set; }
        // public int? RoleID { get; set; }
        // public bool? SuperAdmin { get; set; }
        // public int? AuthoriseRoleID { get; set; }
}
