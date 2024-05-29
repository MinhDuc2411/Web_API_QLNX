using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DATA_DuAn.Models
{
    public class KhachHang
    {
        [Key]
        public int MaKH { get; set; }
        public string? Cccd { get; set; }
        public string? TenKH { get; set; }
        public string? DiaChi { get; set; }
        public string? SoDT { get; set; }
        public string? Email { get; set; }

        // Một khách hàng có thể có nhiều hợp đồng thuê
        public ICollection<HopDongThue> HopDongThues { get; set; }
    }
}
