using System;

namespace DATA_DuAn.DTO.ThanhToanDTO
{
	public class AddThanhToanRequestDTO
	{
		public int MaHopDong { get; set; }
		public DateTime NgayThanhToan { get; set; }
		public decimal SoTien { get; set; }
		public string? PhuongThuc { get; set; }
	}
}
