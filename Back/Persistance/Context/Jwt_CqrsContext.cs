using Back.Core.Domain;
using Back.Persistance.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Back.Persistance.Context
{
    public class Jwt_CqrsContext : DbContext
    {
        public Jwt_CqrsContext(DbContextOptions<Jwt_CqrsContext> options) : base(options)
        {

        }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<AppUser>AppUsers { get; set; }
        public DbSet<Category>Categories { get; set; }
        public DbSet<Product>Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            base.OnModelCreating(modelBuilder);
        }



    }
}
