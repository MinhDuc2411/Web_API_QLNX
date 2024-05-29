using DATA_DuAn.DTO.NhanVienDTO;
using DuAnWeb_QLNX.Repository.NhanVienRepository;
using Microsoft.AspNetCore.Mvc;

namespace DuAnWeb_QLNX.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class NhanVien : ControllerBase
    {
		private readonly INhanVienRepository _nhanVienRepository;

		public NhanVien(INhanVienRepository nhanVienRepository)
		{
			_nhanVienRepository = nhanVienRepository;
		}

		[HttpGet("get-all")]
		public IActionResult GetAllNhanVien()
		{
			var nhanVienList = _nhanVienRepository.GetAllNhanVien();
			return Ok(nhanVienList);
		}

		[HttpGet("get-by-id/{id}")]
		public IActionResult GetNhanVienById(int id)
		{
			var nhanVien = _nhanVienRepository.GetNhanVienById(id);
			if (nhanVien == null)
			{
				return NotFound();
			}
			return Ok(nhanVien);
		}

		[HttpPost("add-NhanVien")]
		public IActionResult AddNhanVien(AddNhanVienRequestDTO addNhanVienRequestDTO)
		{
			if (ModelState.IsValid)
			{
				var bookAdd = _nhanVienRepository.AddNhanVien(addNhanVienRequestDTO);
				return Ok(bookAdd);
			}
			else return BadRequest(ModelState);
		}

		[HttpPut("{id}")]
		public IActionResult UpdateNhanVienById(int id, AddNhanVienRequestDTO nhanVien)
		{
			var updateBook = _nhanVienRepository.UpdateNhanVienById(id, nhanVien);
			return Ok(updateBook);
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteNhanVienById(int id)
		{
			var deleteBook = _nhanVienRepository.DeleteNhanVienById(id);
			return Ok(deleteBook);
		}
}
}
