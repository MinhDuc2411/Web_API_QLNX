using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace DATA_DuAn.Models
{
    public class HopDongThue
    {
        [Key]
        public int MaHopDong { get; set; }
        public int MaKH { get; set; }
        public int MaXe { get; set; }
        public int MaNV { get; set; }
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public decimal TongTien { get; set; }
        public string? TinhTrang { get; set; }

        [ForeignKey("MaKH")]
        public KhachHang KhachHang { get; set; }
        [ForeignKey("MaXe")]
        public DanhMucXe DanhMucXe { get; set; }
        [ForeignKey("MaNV")]
        public NhanVien NhanVien { get; set; }

        // Một hợp đồng thuê có thể có nhiều thanh toán
        public ICollection<ThanhToan> ThanhToans { get; set; }
    }
}
