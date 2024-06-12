using DATA_DuAn.DTO;
using DATA_DuAn.DTO.KhachHangDto;
using DATA_DuAn.DTO.NhanVienDto;
using DATA_DuAn.Models;
namespace DuAnWeb_QLNX.Repository.NhanVienRepository
{
	public interface INhanVienRepository
	{
		List<NhanVienDTO> GetAllNhanVien();
		NhanVienDTO GetNhanVienById(int id);
		AddNhanVienRequestDTO AddNhanVien(AddNhanVienRequestDTO addNhanVienRequestDTO);
		AddNhanVienRequestDTO? UpdateNhanVienById(int id, AddNhanVienRequestDTO nhanVienDTO);
		NhanVien? DeleteNhanVienById(int id);
	}
}
