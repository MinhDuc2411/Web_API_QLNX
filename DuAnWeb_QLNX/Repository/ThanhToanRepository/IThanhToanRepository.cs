using DATA_DuAn.DTO.ThanhToanDTO;

namespace DuAnWeb_QLNX.Repository.ThanhToanRepository
{
	public interface IThanhToanRepository
	{
		List<ThanhToanDTO> GetAllThanhToan();
		ThanhToanDTO GetThanhToanById(int id);
		AddThanhToanRequestDTO AddThanhToan(AddThanhToanRequestDTO addThanhToanRequestDTO);
		AddThanhToanRequestDTO? UpdateThanhToanById(int id, AddThanhToanRequestDTO addThanhToanRequestDTO);
		ThanhToanDTO? DeleteThanhToanById(int id);
	}
}
