using graphql.demo.persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace graphql.demo.persistence.Database;

public class DemoDbContext : DbContext
{
    public DemoDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Company> Companies { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Visitor> Visitors { get; set; }
    public DbSet<Visit> Visits { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>().HasQueryFilter(x => !x.Deleted);
        modelBuilder.Entity<Employee>().HasQueryFilter(x => !x.Deleted);
        modelBuilder.Entity<Visit>().HasQueryFilter(x => !x.Deleted);
        modelBuilder.Entity<Visitor>().HasQueryFilter(x => !x.Deleted);
        
        modelBuilder.Entity<Visit>()
            .HasOne(x => x.Company)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<Visit>()
            .HasOne(x => x.Visitor)
            .WithMany().OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<Visit>()
            .HasOne(x => x.Employee)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);

        base.OnModelCreating(modelBuilder);
    }
}