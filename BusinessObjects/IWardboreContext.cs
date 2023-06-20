using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class IWardboreContext : DbContext
    {
//        public IWardboreContext(DbContextOptions<IWardboreContext> options)
//          : base(options)
//        {
//        }

        public DbSet<CartDetail> CartDetails { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Commnent> Comments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<Favorite> Favorites { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server =(local); database = IWardrobeDB;uid=sa;pwd=123456;");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
    //        modelBuilder.Entity<Product>().HasOne(c => c.User).WithMany().OnDelete(DeleteBehavior.NoAction);
    //        modelBuilder.Entity<Product>().HasOne(c => c.Category).WithMany().OnDelete(DeleteBehavior.NoAction);

        }
    }
}
