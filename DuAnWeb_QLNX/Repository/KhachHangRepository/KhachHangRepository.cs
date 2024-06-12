using DuAnWeb_QLNX.Repository.KhachHangRepository;
using DATA_DuAn.DTO;
using DATA_DuAn.Data;
using DATA_DuAn.Models;
using Microsoft.EntityFrameworkCore;
using DATA_DuAn.DTO.KhachHangDto;


namespace DuAnWeb_QLNX.Repository.KhachHangRepository
{
	public class KhachHangRepository:IKhachHangRepository
	{
			private readonly CarRentalDbContext _context;

			public KhachHangRepository(CarRentalDbContext context)
			{
				_context = context;
			}
		public List<KhachHangDTO> GetAllKhachHang()
		{
			return _context.KhachHang
				.Select(kh => new KhachHangDTO
				{
					MaKH = kh.MaKH,
					Cccd = kh.Cccd,
					TenKH = kh.TenKH,
					DiaChi = kh.DiaChi,
					SoDT = kh.SoDT,
					Email = kh.Email
				})
				.ToList();
		}

		public KhachHangDTO GetKhachHangById(int id)
		{
			var khachHang = _context.KhachHang.FirstOrDefault(kh => kh.MaKH == id);
			if (khachHang == null)
			{
				return null;
			}

			return new KhachHangDTO
			{
				MaKH = khachHang.MaKH,
				Cccd = khachHang.Cccd,
				TenKH = khachHang.TenKH,
				DiaChi = khachHang.DiaChi,
				SoDT = khachHang.SoDT,
				Email = khachHang.Email
			};
		}

		public AddKhachHangRequestDTO AddKhachHang(AddKhachHangRequestDTO addKhachHangRequestDTO)
		{
			var khachHang = new KhachHang
			{
				Cccd = addKhachHangRequestDTO.Cccd,
				TenKH = addKhachHangRequestDTO.TenKH,
				DiaChi = addKhachHangRequestDTO.DiaChi,
				SoDT = addKhachHangRequestDTO.SoDT,
				Email = addKhachHangRequestDTO.Email
			};

			_context.KhachHang.Add(khachHang);
			_context.SaveChanges();

			return addKhachHangRequestDTO;
		}

		public AddKhachHangRequestDTO? UpdateKhachHangById(int id, AddKhachHangRequestDTO khachHangDto)
		{
			var khachHang = _context.KhachHang.Find(id);
			if (khachHang == null) return null;

			khachHang.Cccd = khachHangDto.Cccd;
			khachHang.TenKH = khachHangDto.TenKH;
			khachHang.DiaChi = khachHangDto.DiaChi;
			khachHang.SoDT = khachHangDto.SoDT;
			khachHang.Email = khachHangDto.Email;

			_context.KhachHang.Update(khachHang);
			_context.SaveChanges();

			return khachHangDto;
		}

		public KhachHang? DeleteKhachHangById(int id)
		{
			var khachHang = _context.KhachHang.Find(id);
			if (khachHang == null) return null;

			_context.KhachHang.Remove(khachHang);
			_context.SaveChanges();

			return khachHang;
		}


	}
}

