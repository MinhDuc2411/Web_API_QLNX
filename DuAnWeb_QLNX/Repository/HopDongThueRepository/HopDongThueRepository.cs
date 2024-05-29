using DATA_DuAn.Data;
using DATA_DuAn.DTO.HopDongDto;
using DATA_DuAn.Models;

namespace DuAnWeb_QLNX.Repository.HopDongThueRepository
{
    public class HopDongThueRepository : IHopDongThueRepository
    {
        private readonly CarRentalDbContext _context;

        public HopDongThueRepository(CarRentalDbContext context)
        {
            _context = context;
        }

        public AddHopDongDTO AddHopDong(AddHopDongDTO addHopDong)
        {
            var DomainHopDong = new HopDongThue()
            {              
                MaKH = addHopDong.MaKH,
                MaXe = addHopDong.MaXe,
                MaNV = addHopDong.MaNV,
                NgayBatDau = addHopDong.NgayBatDau,
                NgayKetThuc = addHopDong.NgayKetThuc,
                TongTien = addHopDong.TongTien,
                TinhTrang = addHopDong.TinhTrang,
            };
            _context.HopDongThue.Add(DomainHopDong);
            _context.SaveChanges();
            return addHopDong;
        }

        public HopDongThue Delete(int id)
        {
            var hopDong = _context.HopDongThue.FirstOrDefault(makh=>makh.MaKH == id);
            if (hopDong != null)
            {
                return null;
            }
            _context.HopDongThue.Remove(hopDong);
            _context.SaveChanges();
            return hopDong;
        }

        public List<HopDongThueDTO> GetHopDong()
        {
            var allhopdong = _context.HopDongThue.Select(HopDongThue => new HopDongThueDTO()
            {
               MaHopDong = HopDongThue.MaHopDong,
               MaKH = HopDongThue.MaKH,
               MaXe = HopDongThue.MaXe,
               MaNV = HopDongThue.MaNV,
               NgayBatDau = HopDongThue.NgayBatDau,
               NgayKetThuc = HopDongThue.NgayKetThuc,
               TongTien = HopDongThue.TongTien,
               TinhTrang = HopDongThue.TinhTrang,
            }).ToList();
            return allhopdong;
        }

        public HopDongThueDTO GetHopDong(int id)
        {
            var getMaKh = _context.HopDongThue.Where(HopDongThue => HopDongThue.MaKH == id).ToList();
            var getDomain = getMaKh.Select(HopDongThue => new HopDongThueDTO()
            {
                MaKH = HopDongThue.MaKH,
                MaXe = HopDongThue.MaXe,
                MaNV = HopDongThue.MaNV,
                NgayBatDau = HopDongThue.NgayBatDau,
                NgayKetThuc = HopDongThue.NgayKetThuc,
                TongTien = HopDongThue.TongTien,
                TinhTrang = HopDongThue.TinhTrang,
            }).FirstOrDefault();
            return getDomain;
        }
     
        public List<HopDongThueDTO> GetMaKH(int id)
        {
            return _context.HopDongThue
                           .Where(h => h.MaKH == id) 
                           .Select(h => new HopDongThueDTO
                           {
                               MaHopDong = h.MaHopDong,
                               MaKH = h.MaKH,
                               MaXe = h.MaXe,
                               MaNV = h.MaNV,
                               NgayBatDau = h.NgayBatDau,
                               NgayKetThuc = h.NgayKetThuc,
                               TongTien = h.TongTien,
                               TinhTrang = h.TinhTrang,                                                           
                           })
                           .ToList();
        }

        public AddHopDongDTO PutHopDong(AddHopDongDTO addHopDong, int id)
        {
            var hopdong = _context.HopDongThue.Find(id);
            if (hopdong == null)
            {
                return null;
            }
            hopdong.MaKH = addHopDong.MaKH;
            hopdong.MaNV = addHopDong.MaNV;
            hopdong.MaXe = addHopDong.MaXe;
            hopdong.NgayBatDau = addHopDong.NgayBatDau;
            hopdong.NgayKetThuc = addHopDong.NgayKetThuc;
            hopdong.TinhTrang = addHopDong.TinhTrang;
            hopdong.TongTien = addHopDong.TongTien;
            _context.HopDongThue.Add(hopdong);
            _context.SaveChanges();
            return addHopDong;
        }
    }
}
