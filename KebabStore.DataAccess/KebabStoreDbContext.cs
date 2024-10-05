using KebabStore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace KebabStore.DataAccess;

public class KebabStoreDbContext : DbContext
{
    public KebabStoreDbContext(DbContextOptions<KebabStoreDbContext> options)
        : base(options)
    {
    }

    public DbSet<KebabEntity> Kebabs { get; set; }
}
