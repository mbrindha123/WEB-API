using Microsoft.EntityFrameworkCore;
using PROFILE.Models;

namespace PROFILE.DataAccessLayer{
public class CollegeContext : DbContext
{
    public DbSet<College> Colleges {get; set;} 
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 
        optionsBuilder.UseSqlServer(@"Server=ASPIREREN024\SQLEXPRESS;Database=PMS;Trusted_Connection=True;");
    }
}
}