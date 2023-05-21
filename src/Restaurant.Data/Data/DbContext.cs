using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Restaurant.Data.Data.Models;

namespace Restaurant.Data.Data.Repository
{
    public class Context : DbContext
    {
        private readonly IConfiguration _configuration;

        public Context(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<CategoryModel>? CategoryModel { get; set; }
        public DbSet<ProductModel>? ProductModel { get; set; }
        public DbSet<ServiceModel>? ServiceModel { get; set; }
        public DbSet<TableModel>? TableModel { get; set; }
        public DbSet<WaiterModel>? WaiterModel { get; set; }
        public DbSet<ServiceLineModel>? ServiceLines { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            options.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
    }
}
