using Microsoft.EntityFrameworkCore;

public class MyDbContext(DbContextOptions<MyDbContext> options) : DbContext(options) {
    public DbSet<Health> Health { get; set; }
    public DbSet<Employee> Employee { get; set; }
    public DbSet<Supplier> Supplier { get; set; }
    public DbSet<Category> Category { get; set; }
    public DbSet<Product> Product { get; set; }
    public DbSet<ProductionOrder> ProductionOrder { get; set; }
    public DbSet<ProductionItem> ProductionItem { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Health>().HasNoKey();
    }
}

