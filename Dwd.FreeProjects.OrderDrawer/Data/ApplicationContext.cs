using Dwd.FreeProjects.OrderDrawer.Domain;
using Microsoft.EntityFrameworkCore;

namespace Dwd.FreeProjects.OrderDrawer.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Client> Client { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Product> Product { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb);Database=DwdLab_EFCore;User Id=sa;Password=123;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(x => 
            {
                x.ToTable("Client");
                x.HasKey(x => x.Id);
                x.Property(x => x.Name).HasColumnType("VARCHAR(80)").IsRequired();
                x.Property(x => x.Telephone).HasColumnType("CHAR(11)");
                x.Property(x => x.ZipCode).HasColumnType("CHAR(8)").IsRequired();
                x.Property(x => x.State).HasColumnType("CHAR(2)").IsRequired();
                x.Property(x => x.City).HasColumnType("VARCHAR(80)").IsRequired();

                x.HasIndex(x => x.Telephone).HasName("idx_cliente_telephone");
            });

            modelBuilder.Entity<Product>(x => 
            {
                x.ToTable("Product");
                x.HasKey(x => x.Id);
                x.Property(x => x.BarCode).HasColumnType("CHAR(10)").IsRequired();
                x.Property(x => x.Description).HasColumnType("VARCHAR(200)");
                x.Property(x => x.Value).IsRequired();
                x.Property(x => x.AsProduct).HasConversion<string>();
            });

            modelBuilder.Entity<Order>(x => 
            {
                x.ToTable("Order");
                x.HasKey(x => x.Id);
                x.Property(x => x.Start).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
                x.Property(x => x.Status).HasConversion<string>();
                x.Property(x => x.AsFreight).HasConversion<int>();
                x.Property(x => x.Note).HasColumnType("VARCHAR(300)");

                x.HasMany(x => x.Itens)
                 .WithOne(x => x.Order)
                 .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Item>(x => 
            {
                x.ToTable("Item");
                x.HasKey(x => x.Id);
                x.Property(x => x.Amount).HasDefaultValue(1).IsRequired();
                x.Property(x => x.Value).IsRequired();
                x.Property(x => x.Discount).IsRequired();
            });
        }
    }
}