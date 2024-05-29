using AutoMapper;
using DATA_DuAn.Models;
using DATA_DuAn.DTO.HopDongDto;
using DATA_DuAn.DTO.DanhMucXeDto;
using DATA_DuAn.Data;
namespace DuAnWeb_QLNX.AutoMap
{
    public class AutoMap :Profile
    {
        public AutoMap()
        {
            CreateMap<HopDongThue,HopDongThueDTO>().ReverseMap();
            CreateMap<HopDongThue,AddHopDongDTO>().ReverseMap();
            CreateMap<DanhMucXe,DanhMucXeDTO>().ReverseMap();
            CreateMap<DanhMucXe, AddDanhMucXeDTO>().ReverseMap();
        }

    }
}
