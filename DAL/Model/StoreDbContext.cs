using Microsoft.EntityFrameworkCore;
using System;

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

            #region Customer
            modelBuilder.Entity<Customer>()
                        .HasData(
                        new Customer()
                        {
                            Id = 1,
                            FirstName = "Oleg",
                            LastName = "Reshetilo",
                            Phone = "+380955522990",
                            Email = "oar@intetics.com",
                            City = "Kharkiv",
                            State = "None",
                            Street = "Nauki, 43",
                            ZipCode = 61000
                        },
                        new Customer()
                        {
                            Id = 2,
                            FirstName = "Elena",
                            LastName = "Zub",
                            Phone = "+380976806983",
                            Email = "e.zub@intetics.com",
                            City = "Kharkiv",
                            State = "None",
                            Street = "Nauki, 43",
                            ZipCode = 61000
                        },
                        new Customer()
                        {
                            Id = 3,
                            FirstName = "Olga",
                            LastName = "Pavlenko",
                            Phone = "+380675788903",
                            Email = "o.pavlenko@intetics.com",
                            City = "Kharkiv",
                            State = "None",
                            Street = "Nauki, 43",
                            ZipCode = 61000
                        });
            #endregion

            #region Store
            modelBuilder.Entity<Store>()
                        .HasData(
                        new Store()
                        {
                            Id = 1,
                            Name = "Aliexpress",
                            City = "Wuhan",
                            Email = "support@aliexpress.com",
                            Phone = "+869973856329",
                            State = "China",
                            ZipCode = 430000,
                            Street = "12 Liancheng Rd"
                        },
                        new Store()
                        {
                            Id = 2,
                            Name = "Rozetka",
                            City = "Киев",
                            Email = "support@rozetka.ua",
                            Phone = "0800503808",
                            State = "Украина",
                            ZipCode = 020000,
                            Street = "Георгиевский проулок, 2"
                        },
                        new Store()
                        {
                            Id = 3,
                            Name = "Citilink",
                            City = "Белгород",
                            Email = "support@aliexpress.com",
                            Phone = "+74722218212",
                            State = "Россия",
                            ZipCode = 308024,
                            Street = "ул. Костюкова, 39"
                        },
                        new Store()
                        {
                            Id = 4,
                            Name = "Yandex Market",
                            City = "Киев",
                            Email = "support@yandex.ua",
                            Phone = "0800573878",
                            State = "Украина",
                            ZipCode = 010000,
                            Street = "вул. Антоновича, 50"
                        },
                        new Store()
                        {
                            Id = 5,
                            Name = "M-Video",
                            City = "Курск",
                            Email = "support@m-video.com",
                            Phone = "+78006007775",
                            State = "Россия",
                            ZipCode = 305048,
                            Street = "пр. Дружбы, 9А"
                        },
                        new Store()
                        {
                            Id = 6,
                            Name = "DNS Shop",
                            City = "Мичуринск",
                            Email = "support@aliexpress.com",
                            Phone = "+78007707999",
                            State = "Россия",
                            ZipCode = 393761,
                            Street = "Липецкое шоссе, 12"
                        },
                        new Store()
                        {
                            Id = 7,
                            Name = "Eldorado",
                            City = "Харьков",
                            Email = "support@eldorado.ua",
                            Phone = "0800501478",
                            State = "Украина",
                            ZipCode = 61000,
                            Street = "улица Вернадского, 12"
                        });
            #endregion

            #region Staff
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
            #endregion

            #region Order
            modelBuilder.Entity<Order>()
                       .HasData(
                        new Order()
                        {
                            Id = 1,
                            Status = "Delivered",
                            OrderDate = DateTime.Now,
                            RequiredDate = DateTime.Now,
                            ShippedDate = DateTime.Now,
                            CustomerId = 1,
                            StoreId = 1,
                            StaffId = 1
                        },
                        new Order()
                        {
                            Id = 2,
                            Status = "Awaiting delivery",
                            OrderDate = DateTime.Now,
                            RequiredDate = DateTime.Now,
                            ShippedDate = DateTime.Now,
                            CustomerId = 1,
                            StoreId = 2,
                            StaffId = 2
                        },
                        new Order()
                        {
                            Id = 3,
                            Status = "Delivered",
                            OrderDate = DateTime.Now,
                            RequiredDate = DateTime.Now,
                            ShippedDate = DateTime.Now,
                            CustomerId = 1,
                            StoreId = 3,
                            StaffId = 2
                        },
                        new Order()
                        {
                            Id = 4,
                            Status = "Awaiting delivery",
                            OrderDate = DateTime.Now,
                            RequiredDate = DateTime.Now,
                            ShippedDate = DateTime.Now,
                            CustomerId = 3,
                            StoreId = 4,
                            StaffId = 1
                        },
                        new Order()
                        {
                            Id = 5,
                            Status = "Awaiting delivery",
                            OrderDate = DateTime.Now,
                            RequiredDate = DateTime.Now,
                            ShippedDate = DateTime.Now,
                            CustomerId = 2,
                            StoreId = 5,
                            StaffId = 1
                        },
                        new Order()
                        {
                            Id = 6,
                            Status = "Delivered",
                            OrderDate = DateTime.Now,
                            RequiredDate = DateTime.Now,
                            ShippedDate = DateTime.Now,
                            CustomerId = 2,
                            StoreId = 6,
                            StaffId = 2
                        });
            #endregion

            #region Product
            modelBuilder.Entity<Product>()
                       .HasData(
                        new Product()
                        {
                            Id = 1,
                            Name = "H110M-K",
                            BrandId = 1,
                            CategoryId = 1,
                            ListPrice = 150,
                            ModelYear = 2017
                        },
                        new Product()
                        {
                            Id = 2,
                            Name = "MacBook Pro",
                            BrandId = 2,
                            CategoryId = 1,
                            ListPrice = 2500,
                            ModelYear = 2019
                        },
                        new Product()
                        {
                            Id = 3,
                            Name = "Vivo Book",
                            BrandId = 1,
                            CategoryId = 1,
                            ListPrice = 500,
                            ModelYear = 2018
                        },
                        new Product()
                        {
                            Id = 4,
                            Name = "ThinkPad",
                            BrandId = 3,
                            CategoryId = 1,
                            ListPrice = 300,
                            ModelYear = 2012
                        },
                        new Product()
                        {
                            Id = 5,
                            Name = "630",
                            BrandId = 5,
                            CategoryId = 1,
                            ListPrice = 300,
                            ModelYear = 2013
                        },
                        new Product()
                        {
                            Id = 6,
                            Name = "iPhone 7",
                            BrandId = 2,
                            CategoryId = 1,
                            ListPrice = 500,
                            ModelYear = 2015
                        },
                        new Product()
                        {
                            Id = 7,
                            Name = "i7-6700k",
                            BrandId = 8,
                            CategoryId = 1,
                            ListPrice = 400,
                            ModelYear = 2017
                        },
                        new Product()
                        {
                            Id = 8,
                            Name = "GA-Z270X-Gaming 7",
                            BrandId = 9,
                            CategoryId = 1,
                            ListPrice = 300,
                            ModelYear = 2017
                        },
                        new Product()
                        {
                            Id = 9,
                            Name = "Vengeance LED",
                            BrandId = 10,
                            CategoryId = 1,
                            ListPrice = 100,
                            ModelYear = 2017
                        },
                        new Product()
                        {
                            Id = 10,
                            Name = "860 EVO",
                            BrandId = 12,
                            CategoryId = 1,
                            ListPrice = 100,
                            ModelYear = 2015
                        },
                        new Product()
                        {
                            Id = 11,
                            Name = "CPNS10X Performa",
                            BrandId = 11,
                            CategoryId = 1,
                            ListPrice = 120,
                            ModelYear = 2010
                        });
            #endregion

            #region Brand
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
                        },
                        new Brand()
                        {
                            Id = 3,
                            Name = "Lenovo",
                        },
                        new Brand()
                        {
                            Id = 4,
                            Name = "MSI",
                        },
                        new Brand()
                        {
                            Id = 5,
                            Name = "HP",
                        },
                        new Brand()
                        {
                            Id = 6,
                            Name = "Dell",
                        },
                        new Brand()
                        {
                            Id = 7,
                            Name = "Microsoft",
                        },
                        new Brand()
                        {
                            Id = 8,
                            Name = "Intel",
                        },
                        new Brand()
                        {
                            Id = 9,
                            Name = "Gigabyte",
                        },
                        new Brand()
                        {
                            Id = 10,
                            Name = "Corsair",
                        },
                        new Brand()
                        {
                            Id = 11,
                            Name = "Zalman",
                        },
                        new Brand()
                        {
                            Id = 12,
                            Name = "Samsung",
                        });
            #endregion

            #region Category
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
            #endregion

            #region Stock
            modelBuilder.Entity<Stock>()
                        .HasData(
                        new Stock()
                        {
                            ProductId = 1,
                            StoreId = 1,
                            Quantity = 12,
                        },
                        new Stock()
                        {
                            ProductId = 1,
                            StoreId = 2,
                            Quantity = 44,
                        },
                        new Stock()
                        {
                            ProductId = 1,
                            StoreId = 3,
                            Quantity = 47,
                        },
                        new Stock()
                        {
                            ProductId = 2,
                            StoreId = 2,
                            Quantity = 22
                        },
                        new Stock()
                        {
                            ProductId = 3,
                            StoreId = 3,
                            Quantity = 30
                        },
                        new Stock()
                        {
                            ProductId = 4,
                            StoreId = 4,
                            Quantity = 15
                        },
                        new Stock()
                        {
                            ProductId = 5,
                            StoreId = 5,
                            Quantity = 10
                        },
                        new Stock()
                        {
                            ProductId = 6,
                            StoreId = 6,
                            Quantity = 5
                        });
            #endregion

            #region OrderItem
            modelBuilder.Entity<OrderItem>()
                       .HasData(
                        new OrderItem()
                        {
                            OrderId = 1,
                            ProductId = 1,
                            ListPrice = 1,
                            Quantity = 3,
                            Discount = 5
                        },
                        new OrderItem()
                        {
                            OrderId = 2,
                            ProductId = 2,
                            ListPrice = 1,
                            Quantity = 1,
                            Discount = 0
                        },
                        new OrderItem()
                        {
                            OrderId = 3,
                            ProductId = 3,
                            ListPrice = 1,
                            Quantity = 1,
                            Discount = 10
                        },
                        new OrderItem()
                        {
                            OrderId = 4,
                            ProductId = 4,
                            ListPrice = 1,
                            Quantity = 1,
                            Discount = 0
                        },
                        new OrderItem()
                        {
                            OrderId = 5,
                            ProductId = 5,
                            ListPrice = 1,
                            Quantity = 1,
                            Discount = 0
                        },
                        new OrderItem()
                        {
                            OrderId = 6,
                            ProductId = 6,
                            ListPrice = 1,
                            Quantity = 1,
                            Discount = 0
                        });
            #endregion
        }
    }
}