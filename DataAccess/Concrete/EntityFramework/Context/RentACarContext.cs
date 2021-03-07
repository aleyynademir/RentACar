using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;



namespace DataAccess.Concrete.EntityFramework.Context
{
    public class RentACarContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database=RentACar; Trusted_Connection = true");
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CarImage> CarImages { get; set; }

        public DbSet<Rental> Rentals { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        
        



        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Car>().ToTable("Products");
        //    modelBuilder.Entity<Car>().Property(p => p.CarId).HasColumnName("ProductID");
        //    modelBuilder.Entity<Car>().Property(p => p.BrandId).HasColumnName("CategoryID");
        //    modelBuilder.Entity<Car>().Property(p => p.ColorId).HasColumnName("SupplierID");
        //    modelBuilder.Entity<Car>().Property(p => p.DailyPrice).HasColumnName("UnitPrice");
        //    modelBuilder.Entity<Car>().Property(p => p.ModelYear).HasColumnName("ReorderLevel");

        //    modelBuilder.Entity<Brand>().ToTable("Categories");
        //    modelBuilder.Entity<Brand>().Property(p => p.BrandId).HasColumnName("CategoryID");
        //    modelBuilder.Entity<Brand>().Property(p => p.BrandName).HasColumnName("CategoryName");

        //    modelBuilder.Entity<Color>().ToTable("Suppliers");
        //    modelBuilder.Entity<Color>().Property(p => p.ColorId).HasColumnName("SupplierID");
        //    modelBuilder.Entity<Color>().Property(p => p.ColorName).HasColumnName("CompanyName");


        //}

    }
}
