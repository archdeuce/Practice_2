using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Model
{
    public class StoreDbContext : DbContext
    {
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Store> Stores { get; set; }

        public StoreDbContext()
        {
            this.Database.EnsureDeleted();
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Database = StoreDB; Trusted_Connection = True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Properties and Relations.
            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.ToTable("order_items", "sales");
                entity.Property(p => p.OrderId).HasColumnName("order_id");
                entity.Property(p => p.ProductId).HasColumnName("product_id");
                entity.Property(p => p.Quantity).HasColumnName("quantity");
                entity.Property(p => p.ListPrice).HasColumnName("list_price");
                entity.Property(p => p.Discount).HasColumnName("discount");

                entity.HasKey(oi => new { oi.OrderId, oi.ProductId });

                entity.HasOne(oi => oi.Order)
                      .WithMany(o => o.OrderItems)
                      .HasForeignKey(oi => oi.OrderId);

                entity.HasOne(oi => oi.Product)
                      .WithMany(p => p.OrderItems)
                      .HasForeignKey(oi => oi.ProductId);
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.ToTable("stocks", "production");
                entity.Property(p => p.StoreId).HasColumnName("store_id");
                entity.Property(p => p.ProductId).HasColumnName("product_id");
                entity.Property(p => p.Quantity).HasColumnName("quantity");

                entity.HasKey(s => new { s.StoreId, s.ProductId });

                entity.HasOne(s => s.Store)
                      .WithMany(s => s.Stocks)
                      .HasForeignKey(s => s.StoreId);

                entity.HasOne(s => s.Product)
                      .WithMany(p => p.Stocks)
                      .HasForeignKey(s => s.ProductId);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("orders", "sales");
                entity.Property(p => p.Id).HasColumnName("order_id").ValueGeneratedOnAdd();
                entity.Property(p => p.CustomerId).HasColumnName("customer_id");
                entity.Property(p => p.Status).HasColumnName("order_status");
                entity.Property(p => p.OrderDate).HasColumnName("order_date");
                entity.Property(p => p.RequiredDate).HasColumnName("required_date");
                entity.Property(p => p.ShippedDate).HasColumnName("shipped_date");
                entity.Property(p => p.StoreId).HasColumnName("store_id");
                entity.Property(p => p.StaffId).HasColumnName("staff_id");

                entity.HasOne(o => o.Store)
                      .WithMany(s => s.Orders)
                      .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.ToTable("staffs", "sales");
                entity.Property(p => p.Id).HasColumnName("stuff_id").ValueGeneratedOnAdd();
                entity.Property(p => p.FirstName).HasColumnName("first_name");
                entity.Property(p => p.LastName).HasColumnName("last_name");
                entity.Property(p => p.Email).HasColumnName("email");
                entity.Property(p => p.Phone).HasColumnName("phone");
                entity.Property(p => p.IsActive).HasColumnName("active");
                entity.Property(p => p.StoreId).HasColumnName("store_id");
                entity.Property(p => p.ManagerId).HasColumnName("manager_id");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customers", "sales");
                entity.Property(p => p.Id).HasColumnName("customer_id").ValueGeneratedOnAdd();
                entity.Property(p => p.FirstName).HasColumnName("first_name");
                entity.Property(p => p.LastName).HasColumnName("last_name");
                entity.Property(p => p.Phone).HasColumnName("phone");
                entity.Property(p => p.Email).HasColumnName("email");
                entity.Property(p => p.Street).HasColumnName("street");
                entity.Property(p => p.City).HasColumnName("city");
                entity.Property(p => p.State).HasColumnName("state");
                entity.Property(p => p.ZipCode).HasColumnName("zip_code");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("stores", "sales");
                entity.Property(p => p.Id).HasColumnName("store_id").ValueGeneratedOnAdd();
                entity.Property(p => p.Name).HasColumnName("store_name");
                entity.Property(p => p.Phone).HasColumnName("phone");
                entity.Property(p => p.Email).HasColumnName("email");
                entity.Property(p => p.Street).HasColumnName("street");
                entity.Property(p => p.City).HasColumnName("city");
                entity.Property(p => p.State).HasColumnName("state");
                entity.Property(p => p.ZipCode).HasColumnName("zip_code");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products", "production");
                entity.Property(p => p.Id).HasColumnName("product_id").ValueGeneratedOnAdd();
                entity.Property(p => p.Name).HasColumnName("product_name");
                entity.Property(p => p.BrandId).HasColumnName("brand_id");
                entity.Property(p => p.CategoryId).HasColumnName("category_id");
                entity.Property(p => p.ModelYear).HasColumnName("model_year");
                entity.Property(p => p.ListPrice).HasColumnName("list_price");
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("brands", "production");
                entity.Property(p => p.Id).HasColumnName("brand_id").ValueGeneratedOnAdd();
                entity.Property(p => p.Name).HasColumnName("brand_name");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("categories", "production");
                entity.Property(p => p.Id).HasColumnName("category_id").ValueGeneratedOnAdd();
                entity.Property(p => p.Name).HasColumnName("category_name");
            });
            #endregion

            #region Filling content database.
            modelBuilder.Entity<Customer>()
                        .HasData(
                        new Customer()
                        {
                            Id = 1,
                            FirstName = "Oleg",
                            LastName = "Reshetilo",
                            Phone = "+380955522990",
                            Email = "oar@intetics.com"
                        },
                        new Customer()
                        {
                            Id = 2,
                            FirstName = "Elena",
                            LastName = "Zub",
                            Phone = "+380976806983",
                            Email = "e.zub@intetics.com"
                        });

            modelBuilder.Entity<Store>()
                        .HasData(
                        new Store()
                        {
                            Id = 1,
                            Name = "Aliexpress"
                        },
                        new Store()
                        {
                            Id = 2,
                            Name = "Rozetka"
                        });

            modelBuilder.Entity<Staff>()
                       .HasData(
                        new Staff()
                        {
                            Id = 1,
                            FirstName = "Tanya",
                            LastName = "Ryzhyk",
                            Phone = "+380986231976",
                            Email = "t.ryzhik@intetics.com",
                            StoreId = 1
                        },
                        new Staff()
                        {
                            Id = 2,
                            FirstName = "Vlad",
                            LastName = "Radchenko",
                            Email = "v.radchenko@intetics.com",
                            Phone = "+380990527544",
                            StoreId = 2
                        });

            modelBuilder.Entity<Order>()
                       .HasData(
                        new Order()
                        {
                            Id = 1,
                            Status = "Delivered",
                            CustomerId = 1,
                            StoreId = 1,
                            StaffId = 1
                        },
                        new Order()
                        {
                            Id = 2,
                            Status = "Awaiting delivery",
                            CustomerId = 2,
                            StoreId = 2,
                            StaffId = 2
                        });

            modelBuilder.Entity<Product>()
                       .HasData(
                        new Product()
                        {
                            Id = 1,
                            Name = "PC",
                            BrandId = 1,
                            CategoryId = 1,
                            ListPrice = 1,
                            ModelYear = 2000
                        },
                        new Product()
                        {
                            Id = 2,
                            Name = "Laptop",
                            BrandId = 2,
                            CategoryId = 1,
                            ListPrice = 1,
                            ModelYear = 2020
                        });

            modelBuilder.Entity<Brand>()
                       .HasData(
                        new Brand()
                        {
                            Id = 1,
                            Name = "Asus",
                        },
                        new Brand()
                        {
                            Id = 2,
                            Name = "Apple",
                        });

            modelBuilder.Entity<Category>()
                       .HasData(
                        new Category()
                        {
                            Id = 1,
                            Name = "Hardware",
                        },
                        new Category()
                        {
                            Id = 2,
                            Name = "Software",
                        });

            modelBuilder.Entity<Stock>()
                        .HasData(
                        new Stock()
                        {
                            ProductId = 1,
                            StoreId = 1,
                            Quantity = 10
                        },
                        new Stock()
                        {
                            ProductId = 2,
                            StoreId = 2,
                            Quantity = 2
                        });

            modelBuilder.Entity<OrderItem>()
                       .HasData(
                        new OrderItem()
                        {
                            OrderId = 1,
                            ProductId = 1,
                            ListPrice = 300,
                            Quantity = 3,
                            Discount = 5
                        },
                        new OrderItem()
                        {
                            OrderId = 2,
                            ProductId = 2,
                            ListPrice = 2500,
                            Quantity = 1,
                            Discount = 0
                        });
            #endregion
        }
    }
}