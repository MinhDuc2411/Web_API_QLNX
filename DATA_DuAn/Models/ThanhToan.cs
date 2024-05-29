using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace DATA_DuAn.Models
{
    public class ThanhToan
    {
        [Key]
        public int MaTT { get; set; }
        public int MaHopDong { get; set; }
        public DateTime NgayThanhToan { get; set; }
        public decimal SoTien { get; set; }
        public string? PhuongThuc { get; set; }

        [ForeignKey("MaHopDong")]
        public HopDongThue HopDongThue { get; set; }
    }
}
