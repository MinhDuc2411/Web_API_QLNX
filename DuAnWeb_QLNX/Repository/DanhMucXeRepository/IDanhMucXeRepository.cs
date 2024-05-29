using DATA_DuAn.DTO.DanhMucXeDto;
using DATA_DuAn.Models;
namespace DuAnWeb_QLNX.Repository.DanhMucXeRepository
{
    public interface IDanhMucXeRepository
    {
        List<DanhMucXeDTO> GetDanhMucXe();
        DanhMucXeDTO GetDanhMucXe (int id);
        DanhMucXeDTO GetBienSo (string BienSo);
        AddDanhMucXeDTO AddDanhMucXe(AddDanhMucXeDTO danhmucxe);
        AddDanhMucXeDTO PutDanhMucXe(AddDanhMucXeDTO danhmucxe, int id);
        DATA_DuAn.Models.DanhMucXe Delete(int id);
    }
}
