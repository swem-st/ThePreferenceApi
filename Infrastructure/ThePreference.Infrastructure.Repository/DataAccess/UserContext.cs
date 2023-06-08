using Microsoft.EntityFrameworkCore;
using ThePreference.Infrastructure.Repository.DataModels;
using ThePreference.Infrastructure.Repository.DataModels.User;

namespace ThePreference.Infrastructure.Repository.DataAccess;

public class UserContext : DbContext
{
    // public PeopleContext()
    // {
    // }
    
    public UserContext(DbContextOptions<UserContext> options) : base(options)
    {
        //--startup-project ThePreference.Api --verbos 
    }
    
    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     if (!optionsBuilder.IsConfigured)
    //     {
    //         optionsBuilder.UseSqlServer("Server=localhost,1433;Database=TestTEst;User Id=SA;Password=Qwerty211;");
    //     }
    // }
    
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<AddressEntity> Addresses { get; set; }
}
 