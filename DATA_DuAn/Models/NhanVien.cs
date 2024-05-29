using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DATA_DuAn.Models
{
    public class NhanVien
    {
        [Key]
        public int MaNV { get; set; }
        public string? TenNV { get; set; }
        public string? ChucVu { get; set; }
        public string? SoDT { get; set; }
        public string? Email { get; set; }

        // Một nhân viên có thể quản lý nhiều hợp đồng thuê
        public ICollection<HopDongThue> HopDongThues { get; set; }
    }
}
