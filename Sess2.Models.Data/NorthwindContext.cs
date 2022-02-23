using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Sess2.Models.Data;

#nullable disable

namespace NorthwindDbContext
{
    public partial class NorthwindContext : DbContext
    {
        public NorthwindContext()
        {
        }

        public NorthwindContext(DbContextOptions<NorthwindContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Customercustomerdemo> Customercustomerdemos { get; set; }
        public virtual DbSet<Customerdemographic> Customerdemographics { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Employeeterritory> Employeeterritories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<Shipper> Shippers { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Territory> Territories { get; set; }
        public virtual DbSet<Usstate> Usstates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("host=localhost;database=Northwind;user id=postgres;password=root;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "English_United States.1252");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("categories");

                entity.Property(e => e.Categoryid)
                    .ValueGeneratedNever()
                    .HasColumnName("categoryid");

                entity.Property(e => e.Categoryname)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("categoryname");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Picture).HasColumnName("picture");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customers");

                entity.Property(e => e.Customerid)
                    .HasColumnType("char")
                    .HasColumnName("customerid");

                entity.Property(e => e.Address)
                    .HasMaxLength(60)
                    .HasColumnName("address");

                entity.Property(e => e.City)
                    .HasMaxLength(15)
                    .HasColumnName("city");

                entity.Property(e => e.Companyname)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("companyname");

                entity.Property(e => e.Contactname)
                    .HasMaxLength(30)
                    .HasColumnName("contactname");

                entity.Property(e => e.Contacttitle)
                    .HasMaxLength(30)
                    .HasColumnName("contacttitle");

                entity.Property(e => e.Country)
                    .HasMaxLength(15)
                    .HasColumnName("country");

                entity.Property(e => e.Fax)
                    .HasMaxLength(24)
                    .HasColumnName("fax");

                entity.Property(e => e.Phone)
                    .HasMaxLength(24)
                    .HasColumnName("phone");

                entity.Property(e => e.Postalcode)
                    .HasMaxLength(10)
                    .HasColumnName("postalcode");

                entity.Property(e => e.Region)
                    .HasMaxLength(15)
                    .HasColumnName("region");
            });

            modelBuilder.Entity<Customercustomerdemo>(entity =>
            {
                entity.HasKey(e => new { e.Customerid, e.Customertypeid })
                    .HasName("pk_customercustomerdemo");

                entity.ToTable("customercustomerdemo");

                entity.Property(e => e.Customerid)
                    .HasColumnType("char")
                    .HasColumnName("customerid");

                entity.Property(e => e.Customertypeid)
                    .HasColumnType("char")
                    .HasColumnName("customertypeid");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Customercustomerdemos)
                    .HasForeignKey(d => d.Customerid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_customercustomerdemo_customers");

                entity.HasOne(d => d.Customertype)
                    .WithMany(p => p.Customercustomerdemos)
                    .HasForeignKey(d => d.Customertypeid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_customercustomerdemo_customerdemographics");
            });

            modelBuilder.Entity<Customerdemographic>(entity =>
            {
                entity.HasKey(e => e.Customertypeid)
                    .HasName("pk_customerdemographics");

                entity.ToTable("customerdemographics");

                entity.Property(e => e.Customertypeid)
                    .HasColumnType("char")
                    .HasColumnName("customertypeid");

                entity.Property(e => e.Customerdesc).HasColumnName("customerdesc");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employees");

                entity.Property(e => e.Employeeid)
                    .ValueGeneratedNever()
                    .HasColumnName("employeeid");

                entity.Property(e => e.Address)
                    .HasMaxLength(60)
                    .HasColumnName("address");

                entity.Property(e => e.Birthdate)
                    .HasColumnType("date")
                    .HasColumnName("birthdate");

                entity.Property(e => e.City)
                    .HasMaxLength(15)
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .HasMaxLength(15)
                    .HasColumnName("country");

                entity.Property(e => e.Extension)
                    .HasMaxLength(4)
                    .HasColumnName("extension");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("firstname");

                entity.Property(e => e.Hiredate)
                    .HasColumnType("date")
                    .HasColumnName("hiredate");

                entity.Property(e => e.Homephone)
                    .HasMaxLength(24)
                    .HasColumnName("homephone");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("lastname");

                entity.Property(e => e.Notes).HasColumnName("notes");

                entity.Property(e => e.Photo).HasColumnName("photo");

                entity.Property(e => e.Photopath)
                    .HasMaxLength(255)
                    .HasColumnName("photopath");

                entity.Property(e => e.Postalcode)
                    .HasMaxLength(10)
                    .HasColumnName("postalcode");

                entity.Property(e => e.Region)
                    .HasMaxLength(15)
                    .HasColumnName("region");

                entity.Property(e => e.Reportsto).HasColumnName("reportsto");

                entity.Property(e => e.Title)
                    .HasMaxLength(30)
                    .HasColumnName("title");

                entity.Property(e => e.Titleofcourtesy)
                    .HasMaxLength(25)
                    .HasColumnName("titleofcourtesy");

                entity.HasOne(d => d.ReportstoNavigation)
                    .WithMany(p => p.InverseReportstoNavigation)
                    .HasForeignKey(d => d.Reportsto)
                    .HasConstraintName("fk_employees_employees");
            });

            modelBuilder.Entity<Employeeterritory>(entity =>
            {
                entity.HasKey(e => new { e.Employeeid, e.Territoryid })
                    .HasName("pk_employeeterritories");

                entity.ToTable("employeeterritories");

                entity.Property(e => e.Employeeid).HasColumnName("employeeid");

                entity.Property(e => e.Territoryid)
                    .HasMaxLength(20)
                    .HasColumnName("territoryid");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Employeeterritories)
                    .HasForeignKey(d => d.Employeeid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_employeeterritories_employees");

                entity.HasOne(d => d.Territory)
                    .WithMany(p => p.Employeeterritories)
                    .HasForeignKey(d => d.Territoryid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_employeeterritories_territories");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("orders");

                entity.Property(e => e.Orderid)
                    .ValueGeneratedNever()
                    .HasColumnName("orderid");

                entity.Property(e => e.Customerid)
                    .HasColumnType("char")
                    .HasColumnName("customerid");

                entity.Property(e => e.Employeeid).HasColumnName("employeeid");

                entity.Property(e => e.Freight).HasColumnName("freight");

                entity.Property(e => e.Orderdate)
                    .HasColumnType("date")
                    .HasColumnName("orderdate");

                entity.Property(e => e.Requireddate)
                    .HasColumnType("date")
                    .HasColumnName("requireddate");

                entity.Property(e => e.Shipaddress)
                    .HasMaxLength(60)
                    .HasColumnName("shipaddress");

                entity.Property(e => e.Shipcity)
                    .HasMaxLength(15)
                    .HasColumnName("shipcity");

                entity.Property(e => e.Shipcountry)
                    .HasMaxLength(15)
                    .HasColumnName("shipcountry");

                entity.Property(e => e.Shipname)
                    .HasMaxLength(40)
                    .HasColumnName("shipname");

                entity.Property(e => e.Shippeddate)
                    .HasColumnType("date")
                    .HasColumnName("shippeddate");

                entity.Property(e => e.Shippostalcode)
                    .HasMaxLength(10)
                    .HasColumnName("shippostalcode");

                entity.Property(e => e.Shipregion)
                    .HasMaxLength(15)
                    .HasColumnName("shipregion");

                entity.Property(e => e.Shipvia).HasColumnName("shipvia");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Customerid)
                    .HasConstraintName("fk_orders_customers");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Employeeid)
                    .HasConstraintName("fk_orders_employees");

                entity.HasOne(d => d.ShipviaNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Shipvia)
                    .HasConstraintName("fk_orders_shippers");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.Orderid, e.Productid })
                    .HasName("pk_order_details");

                entity.ToTable("order_details");

                entity.Property(e => e.Orderid).HasColumnName("orderid");

                entity.Property(e => e.Productid).HasColumnName("productid");

                entity.Property(e => e.Discount).HasColumnName("discount");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Unitprice).HasColumnName("unitprice");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.Orderid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_order_details_orders");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.Productid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_order_details_products");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products");

                entity.Property(e => e.Productid)
                    .ValueGeneratedNever()
                    .HasColumnName("productid");

                entity.Property(e => e.Categoryid).HasColumnName("categoryid");

                entity.Property(e => e.Discontinued).HasColumnName("discontinued");

                entity.Property(e => e.Productname)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("productname");

                entity.Property(e => e.Quantityperunit)
                    .HasMaxLength(20)
                    .HasColumnName("quantityperunit");

                entity.Property(e => e.Reorderlevel).HasColumnName("reorderlevel");

                entity.Property(e => e.Supplierid).HasColumnName("supplierid");

                entity.Property(e => e.Unitprice).HasColumnName("unitprice");

                entity.Property(e => e.Unitsinstock).HasColumnName("unitsinstock");

                entity.Property(e => e.Unitsonorder).HasColumnName("unitsonorder");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Categoryid)
                    .HasConstraintName("fk_products_categories");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Supplierid)
                    .HasConstraintName("fk_products_suppliers");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.ToTable("region");

                entity.Property(e => e.Regionid)
                    .ValueGeneratedNever()
                    .HasColumnName("regionid");

                entity.Property(e => e.Regiondescription)
                    .IsRequired()
                    .HasColumnType("char")
                    .HasColumnName("regiondescription");
            });

            modelBuilder.Entity<Shipper>(entity =>
            {
                entity.ToTable("shippers");

                entity.Property(e => e.Shipperid)
                    .ValueGeneratedNever()
                    .HasColumnName("shipperid");

                entity.Property(e => e.Companyname)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("companyname");

                entity.Property(e => e.Phone)
                    .HasMaxLength(24)
                    .HasColumnName("phone");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("suppliers");

                entity.Property(e => e.Supplierid)
                    .ValueGeneratedNever()
                    .HasColumnName("supplierid");

                entity.Property(e => e.Address)
                    .HasMaxLength(60)
                    .HasColumnName("address");

                entity.Property(e => e.City)
                    .HasMaxLength(15)
                    .HasColumnName("city");

                entity.Property(e => e.Companyname)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("companyname");

                entity.Property(e => e.Contactname)
                    .HasMaxLength(30)
                    .HasColumnName("contactname");

                entity.Property(e => e.Contacttitle)
                    .HasMaxLength(30)
                    .HasColumnName("contacttitle");

                entity.Property(e => e.Country)
                    .HasMaxLength(15)
                    .HasColumnName("country");

                entity.Property(e => e.Fax)
                    .HasMaxLength(24)
                    .HasColumnName("fax");

                entity.Property(e => e.Homepage).HasColumnName("homepage");

                entity.Property(e => e.Phone)
                    .HasMaxLength(24)
                    .HasColumnName("phone");

                entity.Property(e => e.Postalcode)
                    .HasMaxLength(10)
                    .HasColumnName("postalcode");

                entity.Property(e => e.Region)
                    .HasMaxLength(15)
                    .HasColumnName("region");
            });

            modelBuilder.Entity<Territory>(entity =>
            {
                entity.ToTable("territories");

                entity.Property(e => e.Territoryid)
                    .HasMaxLength(20)
                    .HasColumnName("territoryid");

                entity.Property(e => e.Regionid).HasColumnName("regionid");

                entity.Property(e => e.Territorydescription)
                    .IsRequired()
                    .HasColumnType("char")
                    .HasColumnName("territorydescription");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Territories)
                    .HasForeignKey(d => d.Regionid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_territories_region");
            });

            modelBuilder.Entity<Usstate>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("usstates");

                entity.Property(e => e.Stateabbr)
                    .HasMaxLength(2)
                    .HasColumnName("stateabbr");

                entity.Property(e => e.Stateid).HasColumnName("stateid");

                entity.Property(e => e.Statename)
                    .HasMaxLength(100)
                    .HasColumnName("statename");

                entity.Property(e => e.Stateregion)
                    .HasMaxLength(50)
                    .HasColumnName("stateregion");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
