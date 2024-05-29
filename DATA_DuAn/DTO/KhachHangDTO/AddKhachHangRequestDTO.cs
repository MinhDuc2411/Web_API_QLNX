using System.ComponentModel.DataAnnotations;

namespace DATA_DuAn.DTO.KhachHangDTO
{
	public class AddKhachHangRequestDTO
	{
		[Required]
		[MinLength(10)]
		public string? Cccd { get; set; }
		public string? TenKH { get; set; }
		public string? DiaChi { get; set; }
		public string? SoDT { get; set; }
		public string? Email { get; set; }
	}
}
