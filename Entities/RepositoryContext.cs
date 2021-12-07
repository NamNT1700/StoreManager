

using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Offices> Offices { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Payments> Payments { get; set; }
        public DbSet<ProductLines> ProductLines { get; set; }
        public DbSet<Products> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure StudentId as FK for StudentAddress
            modelBuilder.Entity<Employees>(Employees =>
            {
                Employees.HasKey(x => x.EmployeeNumber);
                Employees.HasOne(y => y.Offices).WithMany(z => z.Employees).HasForeignKey(d=>d.OfficeCode);
               
                });
            modelBuilder.Entity<Customers>(Customers =>
            {
                Customers.HasKey(x => x.CustomersNumber);
                Customers.HasOne(x => x.Employees).WithMany(y => y.Customers).HasForeignKey(z => z.SalesRepEmployeeNumber);
            });
            modelBuilder.Entity<Offices>().HasKey(x => x.OfficeCode);

            modelBuilder.Entity<OrderDetails>(OrderDetails =>
            {
                OrderDetails.HasKey(x => x.OrderNumber);
                OrderDetails.HasOne(x => x.Products).WithOne(y => y.OrderDetails).HasForeignKey<OrderDetails>(z=>z.ProductCode);
                OrderDetails.HasOne(x => x.Orders).WithOne(y => y.OrderDetails).HasForeignKey<OrderDetails>(z=>z.OrderNumber);
            });

            modelBuilder.Entity<Orders>(Orders =>
            {
                Orders.HasKey(x => x.OrderNumber);
                Orders.HasOne(x => x.Customers).WithMany(y => y.Orders).HasForeignKey(z=>z.CustomersNumber);
            });

            modelBuilder.Entity<Payments>(Payments =>
            {
                Payments.HasKey(x => x.CustomersNumber);
                Payments.HasOne(x => x.Customers).WithOne(y => y.Payments).HasForeignKey<Payments>(z=>z.CustomersNumber);
            });

            modelBuilder.Entity<ProductLines>().HasKey(x => x.ProductLine);

            modelBuilder.Entity<Products>(Products=>{
                Products.HasKey(x => x.ProductCode);
                Products.HasOne(x => x.ProductLines).WithOne(y => y.Products).HasForeignKey<Products>(z => z.ProductLine);
            });



        }
    }
}
