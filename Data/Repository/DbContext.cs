using Microsoft.EntityFrameworkCore;

using TodoApi.Data.Repository.Models;


namespace TodoApi.Data.Repository
{
	public class Context : DbContext
	{
        // public DbSet<Category> Category { get; set; } = null!;
        // public DbSet<ProductModel> Product { get; set; }
        // public DbSet<ProductModel> Product { get; set; }
        // public DbSet<ProductModel> Product { get; set; }
        // public DbSet<ProductModel> Product { get; set; }


        public DbSet<CategoryModel> CategoryModel {get; set; }
        public DbSet<ProductModel> ProductModel {get; set; }
        public DbSet<ServiceModel> ServiceModel {get; set; }
        public DbSet<TableModel> TableModel {get; set; }
        public DbSet<WaiterModel> WaiterModel {get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("DataSource=app.db;Cache=Shared");

    }
}