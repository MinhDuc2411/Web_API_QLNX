using System;

namespace DATA_DuAn.DTO.HopDongDto
{
    public class HopDongThueDTO
    {
        public int MaHopDong { get; set; }
        public int MaKH { get; set; }
        public int MaXe { get; set; }
        public int MaNV { get; set; }
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public decimal TongTien { get; set; }
        public string? TinhTrang { get; set; }
    }
}
