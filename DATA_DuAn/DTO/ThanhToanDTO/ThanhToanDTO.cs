using System;

namespace DATA_DuAn.DTO.ThanhToanDto
{
	public class ThanhToanDTO
	{
		public int MaTT { get; set; }
		public int MaHopDong { get; set; }
		public DateTime NgayThanhToan { get; set; }
		public decimal SoTien { get; set; }
		public string? PhuongThuc { get; set; }
	}
}
