using Microsoft.EntityFrameworkCore;
using ThePreference.Infrastructure.Repository.DataModels;

namespace ThePreference.Infrastructure.Repository.DataAccess;

public class PeopleContext : DbContext
{
    // public PeopleContext()
    // {
    // }
    
    public PeopleContext(DbContextOptions options) : base(options)
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
    
    public DbSet<Person> People { get; set; }
    public DbSet<Address> Addresses { get; set; }
}
 