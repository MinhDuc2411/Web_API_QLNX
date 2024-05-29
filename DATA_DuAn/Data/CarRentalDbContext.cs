using DATA_DuAn.Models;
using Microsoft.EntityFrameworkCore;

namespace DATA_DuAn.Data
{
    public class CarRentalDbContext : DbContext
    {
        public CarRentalDbContext(DbContextOptions<CarRentalDbContext> options) : base(options) { }
        public DbSet<DanhMucXe> DanhMucXe { get; set; }
        public DbSet<HopDongThue> HopDongThue { get; set; }
        public DbSet<KhachHang> KhachHang { get; set; }
        public DbSet<NhanVien>  NhanVien { get; set; }
        public DbSet<ThanhToan> ThanhToan { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Thiết lập các mối quan hệ nếu cần thiết
            modelBuilder.Entity<HopDongThue>()
                .HasOne(h => h.KhachHang)
                .WithMany(k => k.HopDongThues)
                .HasForeignKey(h => h.MaKH);

            modelBuilder.Entity<HopDongThue>()
                .HasOne(h => h.DanhMucXe)
                .WithMany(x => x.HopDongThues)
                .HasForeignKey(h => h.MaXe);

            modelBuilder.Entity<HopDongThue>()
                .HasOne(h => h.NhanVien)
                .WithMany(n => n.HopDongThues)
                .HasForeignKey(h => h.MaNV);

            modelBuilder.Entity<ThanhToan>()
                .HasOne(t => t.HopDongThue)
                .WithMany(h => h.ThanhToans)
                .HasForeignKey(t => t.MaHopDong);
        }
    }
    
}
