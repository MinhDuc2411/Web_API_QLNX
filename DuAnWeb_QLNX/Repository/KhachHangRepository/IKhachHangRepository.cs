using DATA_DuAn.DTO;
using DATA_DuAn.DTO.KhachHangDto;
using DATA_DuAn.Models;
using static System.Reflection.Metadata.BlobBuilder;
namespace DuAnWeb_QLNX.Repository.KhachHangRepository
{
	public interface IKhachHangRepository
	{
		List<KhachHangDTO> GetAllKhachHang();
		KhachHangDTO GetKhachHangById(int id);
		AddKhachHangRequestDTO AddKhachHang(AddKhachHangRequestDTO addKhachHangRequestDTO);
		AddKhachHangRequestDTO? UpdateKhachHangById(int id, AddKhachHangRequestDTO bookDTO);
		KhachHang? DeleteKhachHangById(int id);
	}
}


