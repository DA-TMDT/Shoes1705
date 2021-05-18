using Microsoft.EntityFrameworkCore;
using ShoesAPI.Models;

namespace ShoesAPI.Persistence
{
    public class ShoesStoreDBContext : DbContext
    {
        public ShoesStoreDBContext(DbContextOptions<ShoesStoreDBContext> options) : base(options) {}

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<LoaiSanPham> LoaiSanPhams { get; set; }
        public DbSet<HoaDon> HoaDons{get;set;}
        public DbSet<ChiTietHD> ChiTietHDs{get;set;}
        public DbSet<Quyen> Quyens{get;set;}
        public DbSet<NhanVien> NhanViens{get;set;} 
        // public DbSet<NhanVien> NhanViens{get;set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChiTietHD>()
                .HasKey(o => new { o.bill_id, o.product_id });
        }
    }
}