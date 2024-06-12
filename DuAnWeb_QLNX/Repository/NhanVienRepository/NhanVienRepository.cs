using DATA_DuAn.Data;
using DATA_DuAn.DTO;
using DATA_DuAn.DTO.KhachHangDto;
using DATA_DuAn.DTO.NhanVienDto;
using DATA_DuAn.Models;

namespace DuAnWeb_QLNX.Repository.NhanVienRepository
{
	public class NhanVienRepository : INhanVienRepository
	{
		private readonly CarRentalDbContext _context;

		public NhanVienRepository(CarRentalDbContext context)
		{
			_context = context;
		}


		public List<NhanVienDTO> GetAllNhanVien()
		{
			return _context.NhanVien
				.Select(nv => new NhanVienDTO
				{
					MaNV = nv.MaNV,
					TenNV = nv.TenNV,
					ChucVu = nv.ChucVu,
					SoDT = nv.SoDT,
					Email = nv.Email
				})
				.ToList();
		}

		public NhanVienDTO GetNhanVienById(int id)
		{
			var nhanVien = _context.NhanVien.Find(id);
			if (nhanVien == null) return null;

			return new NhanVienDTO
			{
				MaNV = nhanVien.MaNV,
				TenNV = nhanVien.TenNV,
				ChucVu = nhanVien.ChucVu,
				SoDT = nhanVien.SoDT,
				Email = nhanVien.Email
			};
		}

		public AddNhanVienRequestDTO AddNhanVien(AddNhanVienRequestDTO addNhanVienRequestDTO)
		{
			var nhanVien = new NhanVien
			{
				TenNV = addNhanVienRequestDTO.TenNV,
				ChucVu = addNhanVienRequestDTO.ChucVu, // Assuming ChucVu is mapped from Cccd
				SoDT = addNhanVienRequestDTO.SoDT,
				Email = addNhanVienRequestDTO.Email
			};

			_context.NhanVien.Add(nhanVien);
			_context.SaveChanges();

			return addNhanVienRequestDTO;
		}

		public AddNhanVienRequestDTO? UpdateNhanVienById(int id, AddNhanVienRequestDTO addNhanVienRequestDTO)
		{
			var nhanVien = _context.NhanVien.Find(id);
			if (nhanVien == null) return null;

			nhanVien.TenNV = addNhanVienRequestDTO.TenNV;
			nhanVien.ChucVu = addNhanVienRequestDTO.ChucVu; // Assuming ChucVu is mapped from Cccd
			nhanVien.SoDT = addNhanVienRequestDTO.SoDT;
			nhanVien.Email = addNhanVienRequestDTO.Email;

			_context.NhanVien.Update(nhanVien);
			_context.SaveChanges();

			return addNhanVienRequestDTO;
		}

		public NhanVien? DeleteNhanVienById(int id)
		{
			var nhanVien = _context.NhanVien.Find(id);
			if (nhanVien == null) return null;

			_context.NhanVien.Remove(nhanVien);
			_context.SaveChanges();

			return nhanVien;
		}
	}
}
