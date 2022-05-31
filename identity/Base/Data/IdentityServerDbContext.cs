using Base.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Math.EC.Rfc7748;

namespace Base.Data
{
    public class IdentityServerDbContext : IdentityDbContext<User>
    {
        public IdentityServerDbContext(DbContextOptions<IdentityServerDbContext> options) : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<License> Licenses { get; set; }
        public virtual DbSet<LicenseType> LicenseTypes { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<LicenseTypeProductClaim> LicenseTypeProductClaims { get; set; }
        public virtual DbSet<UserPreferenceSettings> UserPreferenceSettings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>(
                product => {
                    product.ToTable("Product").HasKey(x => x.guid);

                    product.HasMany(x => x.ProductClaims)
                           .WithOne(x => x.Product)
                           .HasForeignKey(x => x.ProductId);
                });

            modelBuilder.Entity<LicenseType>(
                license => {
                    license.HasMany<License>(x => x.Licenses)
                           .WithOne(x => x.LicenseType)
                           .HasForeignKey(x => x.LicenseTypeId);

                    license.ToTable("LicenseType").HasKey(lt => lt.guid);
                }
                );

            modelBuilder.Entity<User>(
                users => {
                    users.HasMany(x => x.Licenses)
                    .WithOne(x => x.User)
                    .HasForeignKey(x => x.UserGuid);

                    users.HasMany(x => x.UserPreferenceSettings)
                    .WithOne(x => x.User)
                    .HasForeignKey(x => x.UserGuid);

                    users.HasOne(x => x.Organization)
                    .WithMany(x => x.Users)
                    .HasForeignKey(x => x.organizationid);
                    users.ToTable("Users").Property(p => p.Id).HasColumnName("UserId");
                });

            modelBuilder.Entity<Organization>(
                Organization => {
                    Organization.HasMany(o => o.Users)
                                .WithOne(u => u.Organization)
                                .HasForeignKey(o => o.organizationid);

                    Organization.ToTable("Organization").Property(p => p.Guid).HasColumnName("Guid");
                    Organization.HasKey(x => x.Guid);

                    Organization.HasMany(x => x.Licenses)
                                .WithOne(x => x.Organization)
                                .HasForeignKey(x => x.OrganizationId);
                });

            modelBuilder.Entity<License>(
                license => {
                    license.HasMany(x => x.LicenseClaims)
                           .WithOne(x => x.License)
                           .HasForeignKey(x => x.LicenseGuid);

                    license.HasOne(x => x.User)
                            .WithMany(x => x.Licenses)
                            .HasForeignKey(x => x.UserGuid);

                    license.ToTable("License").Property(p => p.Guid).HasColumnName("Guid");
                });

            modelBuilder.Entity<LicenseClaims>(
                licenseClaims => {
                    licenseClaims.ToTable("LicenseClaims").HasKey(x => x.Guid);
                });

            modelBuilder.Entity<ProductClaim>(
                ProductClaim => {
                    ProductClaim.ToTable("ProductClaim").HasKey(x => x.guid);
                });
            modelBuilder.Entity<LicenseTypeProductClaim>(LtPc => {
                LtPc.HasKey(x => new { x.LicenseTypeId, x.ProductClaimId });
                LtPc.HasOne(x => x.ProductClaim)
                    .WithMany(x => x.LicenseTypeProductClaims)
                    .HasForeignKey(x => x.ProductClaimId);
                LtPc.HasOne(x => x.LicenseType)
                    .WithMany(x => x.LicenseTypeProductClaims)
                    .HasForeignKey(x => x.LicenseTypeId);
            });

            modelBuilder.Entity<UserPreferenceSettings>(Ups => {
                Ups.HasKey(x => x.Guid);
                Ups.HasOne(x => x.Product)
                   .WithOne(x => x.UserPreferenceSettings)
                   .HasForeignKey<UserPreferenceSettings>(x => x.ProductId);
                   
            });

            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
        }
    }
}