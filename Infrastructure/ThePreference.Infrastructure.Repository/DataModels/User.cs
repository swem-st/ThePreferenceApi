// using System;
// using System.Collections.Generic;
// using System.ComponentModel.DataAnnotations.Schema;
// using System.Data.Entity.Spatial;
using System.ComponentModel.DataAnnotations;

namespace ThePreference.Infrastructure.DataModels;

public class User
{
        public int UserID { get; set; }

        [StringLength(500)]
        public string FirstName { get; set; }

        [StringLength(500)]
        public string LastName { get; set; }

        // [StringLength(128)]
        // public string Username { get; set; }
        //
        // [StringLength(128)]
        // public string Password { get; set; }
        //
        // [StringLength(128)]
        // public string Email { get; set; }
        //
        // public DateTime? LastLoggedOn { get; set; }
        //
        // public int? ManagerId { get; set; }
        //
        // [StringLength(128)]
        // public string Token { get; set; }
        //
        // public bool? isActive { get; set; }
        //
        // public bool? isDeleted { get; set; }
        //
        // public int AccountID { get; set; }
        //
        // public int? PermissionRoleID { get; set; }
        //
        // public int? RoleID { get; set; }
        //
        // public bool? SuperAdmin { get; set; }
        //
        // public bool? ActiveDirectoryLogin { get; set; }
        //
        // public int? AuthoriseRoleID { get; set; }
    
        // public virtual account account { get; set; }
}
