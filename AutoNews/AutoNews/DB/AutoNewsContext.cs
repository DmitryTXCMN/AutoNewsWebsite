using Microsoft.EntityFrameworkCore;

namespace AutoNews.DB;

public class AutoNewsContext : BaseDbContext
{
    protected override string Catalog => Config.AutoNewsCatalog;
    
    public DbSet<User> Users { get; set; }
}
