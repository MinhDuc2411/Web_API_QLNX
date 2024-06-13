using DATA_DuAn.Data;
using DATA_DuAn.DTO.NhanVienDto;
using DATA_DuAn.DTO.ThanhToanDto;
using DATA_DuAn.Models;

namespace DuAnWeb_QLNX.Repository.ThanhToanRepository
{
	public class ThanhToanRepository :IThanhToanRepository
	{
		private readonly CarRentalDbContext _context;

		public ThanhToanRepository(CarRentalDbContext context)
		{
			_context = context;
		}

		public List<ThanhToanDTO> GetAllThanhToan()
		{
			return _context.ThanhToan
				.Select(tt => new ThanhToanDTO
				{
					MaTT = tt.MaTT,
					MaHopDong = tt.MaHopDong,
					NgayThanhToan = tt.NgayThanhToan,
					SoTien = tt.SoTien,
					PhuongThuc = tt.PhuongThuc
				})
				.ToList();
		}

		public ThanhToanDTO GetThanhToanById(int id)
		{
			var thanhToan = _context.ThanhToan.Find(id);
			if (thanhToan == null) return null;

			return new ThanhToanDTO
			{
				MaTT = thanhToan.MaTT,
				MaHopDong = thanhToan.MaHopDong,
				NgayThanhToan = thanhToan.NgayThanhToan,
				SoTien = thanhToan.SoTien,
				PhuongThuc = thanhToan.PhuongThuc
			};
		}

		public AddThanhToanRequestDTO AddThanhToan(AddThanhToanRequestDTO addThanhToanRequestDTO)
		{
			var thanhToan = new ThanhToan
			{
				MaHopDong = addThanhToanRequestDTO.MaHopDong,
				NgayThanhToan = addThanhToanRequestDTO.NgayThanhToan,
				SoTien = addThanhToanRequestDTO.SoTien,
				PhuongThuc = addThanhToanRequestDTO.PhuongThuc
			};

			_context.ThanhToan.Add(thanhToan);
			_context.SaveChanges();

			return addThanhToanRequestDTO;

		}


		public AddThanhToanRequestDTO? UpdateThanhToanById(int id, AddThanhToanRequestDTO addThanhToanRequestDTO)
		{
			var thanhToan = _context.ThanhToan.Find(id);
			if (thanhToan == null) return null;

			thanhToan.MaHopDong = addThanhToanRequestDTO.MaHopDong;
			thanhToan.NgayThanhToan = addThanhToanRequestDTO.NgayThanhToan;
			thanhToan.SoTien = addThanhToanRequestDTO.SoTien;
			thanhToan.PhuongThuc = addThanhToanRequestDTO.PhuongThuc;

			_context.ThanhToan.Update(thanhToan);
			_context.SaveChanges();
			 
			return addThanhToanRequestDTO;
			
		}

		public ThanhToanDTO? DeleteThanhToanById(int id)
		{
			var thanhToan = _context.ThanhToan.Find(id);
			if (thanhToan == null) return null;

			_context.ThanhToan.Remove(thanhToan);
			_context.SaveChanges();

			return new ThanhToanDTO
			{
				MaTT = thanhToan.MaTT,
				MaHopDong = thanhToan.MaHopDong,
				NgayThanhToan = thanhToan.NgayThanhToan,
				SoTien = thanhToan.SoTien,
				PhuongThuc = thanhToan.PhuongThuc
			};
		}
	}
}

