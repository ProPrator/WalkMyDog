using Microsoft.EntityFrameworkCore;
using WalkMyDog.Api.Entities;

namespace WalkMyDog.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // Эта строчка скажет EF создать таблицу Users
    public DbSet<User> Users => Set<User>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Пример: делаем Email уникальным индексом (как в Symfony через атрибуты)
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();
    }
}