using Microsoft.EntityFrameworkCore;

namespace Backend.Models
{
    public class WishListContext : DbContext
    {
        public WishListContext(DbContextOptions<WishListContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WishListItem>()
                .HasKey(i => i.ItemId);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<WishList> WishLists { get; set; }
        public DbSet<WishListItem> WishListItems { get; set; }
    }
}