

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
                Employees.HasKey(x => x.EmployeeId);
                Employees.HasOne(y => y.Offices).WithMany(y => y.Employees).HasForeignKey(z => z.OfficeIdFK);
                Employees.HasOne(x => x.EmployeesBoss).WithMany(y => y.EmployeesOfMine).HasForeignKey(z => z.EmployeeId);

            });
            modelBuilder.Entity<Customers>(Customers =>
            {
                Customers.HasKey(x => x.CustomersId);
                Customers.HasOne(x => x.Employees).WithMany(y => y.Customers).HasForeignKey(z => z.EmployeeIdFK);
            });
            modelBuilder.Entity<Offices>(Offices =>
            {
                Offices.HasKey(x => x.OfficeId);
                Offices.HasMany(x => x.Employees).WithOne(y => y.Offices).HasForeignKey(z => z.OfficeIdFK);
            });

            modelBuilder.Entity<OrderDetails>(OrderDetails =>
            {
                OrderDetails.HasKey(x => x.ProductCodeFK);
                OrderDetails.HasOne(x => x.Products).WithOne(y => y.OrderDetails).HasForeignKey<OrderDetails>(z => z.ProductCodeFK);
                OrderDetails.HasOne(x => x.Orders).WithOne(y => y.OrderDetails).HasForeignKey<OrderDetails>(z => z.OrderNumberFK);
            });

            modelBuilder.Entity<Orders>(Orders =>
            {
                Orders.HasKey(x => x.OrderNumber);
                Orders.HasOne(x => x.Customers).WithMany(y => y.Orders).HasForeignKey(z => z.CustomersFK);
            });

            modelBuilder.Entity<Payments>(Payments =>
            {
                Payments.HasKey(x => x.CustomersIdFK);
                Payments.HasOne(x => x.Customers).WithOne(y => y.Payments).HasForeignKey<Payments>(z => z.CustomersIdFK);
            });

            modelBuilder.Entity<ProductLines>(ProductLines =>
            {
                ProductLines.HasKey(x => x.ProductId);
                ProductLines.HasMany(x => x.Products).WithOne(y => y.ProductLines).HasForeignKey(z => z.ProductIdFK);
            });

            modelBuilder.Entity<Products>(Products =>
            {
                Products.HasKey(x => x.ProductCode);
                Products.HasOne(x => x.ProductLines).WithMany(y => y.Products).HasForeignKey(z => z.ProductIdFK);
            });



        }
    }
}
