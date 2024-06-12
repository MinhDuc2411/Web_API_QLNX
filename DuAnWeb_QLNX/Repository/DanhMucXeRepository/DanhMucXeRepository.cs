using Microsoft.EntityFrameworkCore;
using DATA_DuAn.Data;
using DATA_DuAn.Models;
using DATA_DuAn.DTO.DanhMucXeDto;
using DuAnWeb_QLNX.Repository.DanhMucXeRepository;
namespace DuAnWeb_QLNX.Repository.DanhMucXe
{
    public class DanhMucXeRepository : IDanhMucXeRepository
    {
        private readonly CarRentalDbContext _context;

        public DanhMucXeRepository(CarRentalDbContext context)
        {
            _context = context;
        }

        public List<DanhMucXeDTO> GetDanhMucXe()
        {
            var allDanhMucXe = _context.DanhMucXe.Select(xe => new DanhMucXeDTO()
            {
                MaXe = xe.MaXe,
                BienSo = xe.BienSo,
                HangXe = xe.HangXe,
                MauSac = xe.MauSac,
                GiaThue = xe.GiaThue,
                TrangThai = xe.TrangThai,
                Image = xe.URl
            }).ToList();
            return allDanhMucXe;
        }
        public AddDanhMucXeDTO AddDanhMucXe(AddDanhMucXeDTO danhmucxe)
        {
            var DanhMucXeDomain = new DATA_DuAn.Models.DanhMucXe()
            {
                BienSo = danhmucxe.BienSo,
                HangXe = danhmucxe.HangXe,
                MauSac = danhmucxe.MauSac,
                GiaThue = (decimal)danhmucxe.GiaThue,
                TrangThai = danhmucxe.TrangThai,
                URl = danhmucxe.Image
            };
            _context.DanhMucXe.Add(DanhMucXeDomain);
            _context.SaveChanges();
            return danhmucxe;
        }

        public AddDanhMucXeDTO PutDanhMucXe(AddDanhMucXeDTO addDanhMucXe, int id)
        {
            var xe = _context.DanhMucXe.FirstOrDefault(x=>x.MaXe == id);
            xe.BienSo = addDanhMucXe.BienSo;
            xe.HangXe = addDanhMucXe.HangXe;
            xe.MauSac = addDanhMucXe.MauSac;
            xe.GiaThue = addDanhMucXe.GiaThue;
            xe.TrangThai = addDanhMucXe.TrangThai;
            xe.URl = addDanhMucXe.Image;
            _context.SaveChanges();

            return addDanhMucXe;
        }

        public DATA_DuAn.Models.DanhMucXe Delete(int id)
        {
            var xe = _context.DanhMucXe.Find(id);
            if (xe == null)
            {
                return null;
            }

            _context.DanhMucXe.Remove(xe);
            _context.SaveChanges();

            return xe;
        }

        List<DanhMucXeDTO> IDanhMucXeRepository.GetBienSo(string BienSo)
        {

            var xe = _context.DanhMucXe.Where(x => x.BienSo.ToLower().Contains(BienSo.ToLower()));
            var xeid = xe.Select(x => new DanhMucXeDTO()
            {
                MaXe = x.MaXe,
                BienSo = x.BienSo,
                HangXe = x.HangXe,
                MauSac = x.MauSac,
                GiaThue = x.GiaThue,
                TrangThai = x.TrangThai,
                Image = x.URl
            }).ToList();
            return xeid;
        }

        public DanhMucXeDTO GetMaXe(int id)
        {
            var xe = _context.DanhMucXe.Where(x => x.MaXe == id);
            var xeid = xe.Select(x => new DanhMucXeDTO()
            {
                MaXe = x.MaXe,
                BienSo = x.BienSo,
                HangXe = x.HangXe,
                MauSac = x.MauSac,
                GiaThue = x.GiaThue,
                TrangThai = x.TrangThai,
                Image = x.URl
            }).FirstOrDefault();
            return xeid;
        }
    }
}
