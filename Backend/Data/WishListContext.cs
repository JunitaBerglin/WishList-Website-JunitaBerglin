using Microsoft.EntityFrameworkCore;

namespace Backend.Models
{
    public class WishListContext : DbContext
    {
        public WishListContext(DbContextOptions<WishListContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users => Set<User>();
        public DbSet<WishList> WishLists => Set<WishList>();
        public DbSet<WishListItem> WishListItems => Set<WishListItem>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WishListItem>()
                .HasKey(i => i.ItemId);

            modelBuilder.Entity<WishListItem>()
                .Property(i => i.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<WishList>()
                .HasOne(w => w.User)
                .WithMany(u => u.WishLists)
                .HasForeignKey(w => w.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<WishListItem>()
                .HasOne(i => i.WishList)
                .WithMany(w => w.Items)
                .HasForeignKey(i => i.WishListId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<WishListItem>()
                .HasOne(i => i.PurchasedBy)
                .WithMany()
                .HasForeignKey(i => i.PurchasedByUserId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}