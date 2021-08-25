using Microsoft.EntityFrameworkCore;
using ApiVendaFacil.Models;

namespace ApiVendaFacil.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=database.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            // modelBuilder.Entity<Category>()
                // .HasMany<Product>(category => category.Products);

            modelBuilder.Entity<Product>()
                .HasOne<Category>(product => product.Category);

            modelBuilder.Entity<Order>()
                .HasMany<OrderItem>(order => order.Items);
                //.WithOne(orderItem => orderItem.Order)
                //.HasForeignKey(orderItem => orderItem.OrderId);
            
            modelBuilder.Entity<User>()
                .HasMany<Order>(user => user.Orders);
            
            modelBuilder.Entity<Customer>()
                .HasMany<Order>(customer => customer.Orders);
        }
    }
}