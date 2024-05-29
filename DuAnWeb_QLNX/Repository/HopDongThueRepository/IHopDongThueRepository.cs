using DATA_DuAn.DTO.HopDongDto;
using DATA_DuAn.Models;

namespace DuAnWeb_QLNX.Repository.HopDongThueRepository
{
    public interface IHopDongThueRepository
    {
        List<HopDongThueDTO> GetHopDong();
        HopDongThueDTO GetHopDong(int id);
        List<HopDongThueDTO> GetMaKH(int id);
        AddHopDongDTO AddHopDong(AddHopDongDTO addHopDong);
        AddHopDongDTO PutHopDong(AddHopDongDTO addHopDong, int id);
        DATA_DuAn.Models.HopDongThue Delete(int id);
    }
}
