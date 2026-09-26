using Microsoft.EntityFrameworkCore;
using MinieCommerce.Core.Entities;

namespace MinieCommerce.Core.Context;

internal class CommerceDb : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<OrderItem> OrderItems { get; set; } = null!;
    public DbSet<Payment> Payments { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;

    override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var stringConnection = "Server=localhost;Database=MinieCommerce;User Id=sa;Password=YourStrong!Passw0rd;";
        optionsBuilder.UseSqlServer(stringConnection);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CommerceDb).Assembly);
    }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }
}