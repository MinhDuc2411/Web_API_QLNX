using DATA_DuAn.DTO.HopDongDto;
using DATA_DuAn.Models;

namespace DuAnWeb_QLNX.Repository.HopDongThueRepository
{
    public interface IHopDongThueRepository
    {
        List<HopDongThueDTO> GetHopDong();
        HopDongThueDTO GetHopDongById(int id);
        List<HopDongThueDTO> GetHopDongByMaKH(int maKH); // Lấy hợp đồng theo mã khách hàng
        AddHopDongDTO AddHopDong(AddHopDongDTO addHopDong);
        AddHopDongDTO PutHopDong(AddHopDongDTO addHopDong, int id);
        DATA_DuAn.Models.HopDongThue Delete(int id);
    }
}
