using Microsoft.EntityFrameworkCore;
using OtoServisSatis.Entities.Models;

namespace OtoServisSatis.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Arac> Araclar { get; set; }
    public DbSet<Kullanici> Kullanicilar { get; set; }
    public DbSet<Marka> Markalar { get; set; }
    public DbSet<Musteri> Musteriler { get; set; }
    public DbSet<Rol> Roller { get; set; }
    public DbSet<Satis> Satislar { get; set; }
    public DbSet<Servis> Servisler { get; set; }
    public DbSet<Slider> Sliders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            @"Server=localhost;Database=OtoServisSatis;User Id=SA;Password=reallyStrongPwd123;TrustServerCertificate=true");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Fluent API
        modelBuilder.Entity<Marka>().Property(m => m.Ad).IsRequired().HasColumnType("varchar(50)");
        modelBuilder.Entity<Rol>().Property(m => m.Ad).IsRequired().HasColumnType("varchar(50)");

        modelBuilder.Entity<Rol>().HasData(new Rol
        {
            Id = 1,
            Ad = "Admin"
        });
        
        modelBuilder.Entity<Kullanici>().HasData(new Kullanici
        {
            Id = 1,
            Ad = "Admin",
            AktifMi = true,
            EklenmeTarihi = DateTime.Now,
            Email = "admin@aracsatis.com",
            KullaniciAdi = "admin",
            Sifre = "1234",
           //Rol = new Rol { Id = 1 },
            RolId = 1,
            SoyAd = "admin",
            Telefon = "0850",
        });
        base.OnModelCreating(modelBuilder);
    }
}