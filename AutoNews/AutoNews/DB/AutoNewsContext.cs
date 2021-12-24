using Microsoft.EntityFrameworkCore;

namespace AutoNews.DB;

public class AutoNewsContext : BaseDbContext
{
    protected override string Catalog => Config.AutoNewsCatalog;
    
    public DbSet<User> Users { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<News> News { get; set; }
    public DbSet<Like> Likes { get; set; }
}
