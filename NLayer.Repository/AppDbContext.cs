using Microsoft.EntityFrameworkCore;
using NLayer.Core;
using NLayer.Repository.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository
{
    public class AppDbContext : DbContext
    {
        ////Veritabanı yolunu startup dosyasından vereceğimiz için options kullanıyoruz

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)     
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductFeature> ProductFeatures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //modelBuilder.ApplyConfiguration(new ProductConfiguration());   Tek tek tanımlamak yerine yukaridakini kullanmak daha mantıklı

            modelBuilder.Entity<ProductFeature>().HasData(
            new ProductFeature()
            {
                Id = 1,
                Color = "Kırmızı",
                Height = 100,
                Width = 200,
                ProductId = 1,

            },
            new ProductFeature()
            {
                Id = 2,
                Color = "Mavi",
                Height = 300,
                Width = 500,
                ProductId = 2,

            });


            base.OnModelCreating(modelBuilder);
        }

    }
}
