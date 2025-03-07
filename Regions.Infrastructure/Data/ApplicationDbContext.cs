using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Regions.Domain.Entities;

namespace Regions.Infrastructure.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<District> Districts { get; set; }

    public virtual DbSet<Province> Provinces { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=.;Database=Regions;Trusted_Connection=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__City__3214EC07595D4C62");

            entity.ToTable("City");

            entity.HasIndex(e => new { e.Name, e.ProvinceId }, "UQ_City_Name_Province").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.Province).WithMany(p => p.Cities)
                .HasForeignKey(d => d.ProvinceId)
                .HasConstraintName("FK__City__ProvinceId__3B75D760");
        });

        modelBuilder.Entity<District>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__District__3214EC073083F268");

            entity.ToTable("District");

            entity.HasIndex(e => new { e.Name, e.CityId }, "UQ_District_Name_City").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.City).WithMany(p => p.Districts)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK__District__CityId__3F466844");
        });

        modelBuilder.Entity<Province>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Province__3214EC07A12DB230");

            entity.ToTable("Province");

            entity.HasIndex(e => e.Name, "UQ__Province__737584F666A1C1A2").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        // Seed Data
        /*modelBuilder.Entity<Province>().HasData(
            new Province { Id = 1, Name = "تهران" },
            new Province { Id = 2, Name = "اصفهان" }
        );
        modelBuilder.Entity<City>().HasData(
            new City { Id = 1, Name = "تهران", ProvinceId = 1 },
            new City { Id = 2, Name = "کاشان", ProvinceId = 2 }
        );
        modelBuilder.Entity<District>().HasData(
            new District { Id = 1, Name = "منطقه 1", CityId = 1 },
            new District { Id = 2, Name = "منطقه 2", CityId = 1 }
        );*/

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
