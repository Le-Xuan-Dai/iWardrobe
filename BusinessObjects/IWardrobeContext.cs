using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace BusinessObjects
{
    public class IWardrobeContext : IdentityDbContext<User>
    {
        public IWardrobeContext()
        {
        }

        public IWardrobeContext(DbContextOptions<IWardrobeContext> options)
          : base(options)
        {
        }

        public DbSet<CartDetail> CartDetails { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<Favorite> Favorites { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.AddInterceptors(new SoftDeleteInterceptor());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>()
                .Property(b => b.CreationDate)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Product>()
           .Property(e => e.ImageUrls)
           .HasConversion(
               v => string.Join(',', v),
               v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));

            modelBuilder.Entity<User>()
           .Property(e => e.IdentificationCardImgs)
           .HasConversion(
               v => string.Join(',', v),
               v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName.Substring(6));
                }
            }

            modelBuilder.Entity<CartDetail>().Property(b => b.IsDeleted).HasDefaultValue(false);
            modelBuilder.Entity<Category>().Property(b => b.IsDeleted).HasDefaultValue(false);
            modelBuilder.Entity<Comment>().Property(b => b.IsDeleted).HasDefaultValue(false);
            modelBuilder.Entity<Order>().Property(b => b.IsDeleted).HasDefaultValue(false);
            modelBuilder.Entity<Product>().Property(b => b.IsDeleted).HasDefaultValue(false);
            modelBuilder.Entity<User>().Property(b => b.IsDeleted).HasDefaultValue(false);
            modelBuilder.Entity<Voucher>().Property(b => b.IsDeleted).HasDefaultValue(false);
            modelBuilder.Entity<Favorite>().Property(b => b.IsDeleted).HasDefaultValue(false);

            modelBuilder.Entity<CartDetail>().HasQueryFilter(x => x.IsDeleted == false);
            modelBuilder.Entity<Category>().HasQueryFilter(x => x.IsDeleted == false);
            modelBuilder.Entity<Comment>().HasQueryFilter(x => x.IsDeleted == false);
            modelBuilder.Entity<Order>().HasQueryFilter(x => x.IsDeleted == false);
            modelBuilder.Entity<Product>().HasQueryFilter(x => x.IsDeleted == false);
            modelBuilder.Entity<User>().HasQueryFilter(x => x.IsDeleted == false);
            modelBuilder.Entity<Voucher>().HasQueryFilter(x => x.IsDeleted == false);
            modelBuilder.Entity<Favorite>().HasQueryFilter(x => x.IsDeleted == false);
        }
    }
}
