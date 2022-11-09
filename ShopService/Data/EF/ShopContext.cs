using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ShopService.Data.EF
{
    public partial class ShopContext : DbContext
    {
        public ShopContext()
        {
        }

        public ShopContext(DbContextOptions<ShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Itemtype> Itemtypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("DataSource=Sqlite/Shop.db;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("ITEMS");

                entity.Property(e => e.Id)
                    .HasColumnType("INT IDENTITY(1,1)")
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Baseprice)
                    .IsRequired()
                    .HasColumnType("DECIMAL(8,2)")
                    .HasColumnName("BASEPRICE");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("VARCHAR(128)")
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("VARCHAR(50)")
                    .HasColumnName("NAME");

                entity.Property(e => e.Quantity)
                    .HasColumnType("INT")
                    .HasColumnName("QUANTITY");

                entity.Property(e => e.Typeid)
                    .HasColumnType("INT")
                    .HasColumnName("TYPEID");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.Typeid)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Itemtype>(entity =>
            {
                entity.ToTable("ITEMTYPES");

                entity.Property(e => e.Id)
                    .HasColumnType("INT IDENTITY(1,1)")
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("VARCHAR(50)")
                    .HasColumnName("NAME");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
