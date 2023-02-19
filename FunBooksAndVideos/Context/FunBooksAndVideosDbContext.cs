using FunBooksAndVideos.Context.Models;
using Microsoft.EntityFrameworkCore;

namespace FunBooksAndVideos.Context
{
    public class FunBooksAndVideosDbContext : DbContext
    {
        public FunBooksAndVideosDbContext(DbContextOptions<FunBooksAndVideosDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Product> Items { get; set; }
        public DbSet<ProductCategory> ItemCategories { get; set; }
        public DbSet<ProductStock> ItemStock { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> ItemsItems { get; set; }
        public DbSet<PaymentType> PaymentType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserMembership>().HasKey(x => new { x.UserId, x.MembershipId });

            modelBuilder.Entity<UserMembership>()
                .HasOne(pc => pc.User)
                .WithMany(p => p.UserMemberships)
                .HasForeignKey(pc => pc.UserId);

            modelBuilder.Entity<UserMembership>()
                .HasOne(pc => pc.Membership)
                .WithMany(c => c.UserMemberships)
                .HasForeignKey(pc => pc.MembershipId);

            modelBuilder.Entity<ProductCategory>()
                .HasOne(e => e.Product)
                .WithOne(em => em.ProductCategory)
                .HasForeignKey<Product> (em => em.ProductCategoryId);

            modelBuilder.Entity<ProductStock>()
                .HasOne(e => e.Product)
                .WithOne(em => em.ProductStock)
                .HasForeignKey<Product>(em => em.ProductStockId);

            modelBuilder.Entity<Order>()
                .HasMany(c => c.OrderItems)
                .WithOne(e => e.Order);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.OrderItems)
                .WithOne(p => p.Product);

            modelBuilder.Entity<Order>()
                .HasOne(e => e.PaymentType)
                .WithOne(o => o.Order)
                .HasForeignKey<Order>(p => p.PaymentTypeId);
        }
    }
}
