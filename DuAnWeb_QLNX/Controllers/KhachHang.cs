using DATA_DuAn.DTO.HopDongDto;
using DATA_DuAn.DTO;
using DuAnWeb_QLNX.Repository.KhachHangRepository;
using Microsoft.AspNetCore.Mvc;
using DATA_DuAn.DTO.KhachHangDto;
using DATA_DuAn.DTO.NhanVienDto;


namespace DuAnWeb_QLNX.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	
	public class KhachHang : ControllerBase
    {
		private readonly IKhachHangRepository _khachHangRepository;

		public KhachHang(IKhachHangRepository khachHangRepository)
		{
			_khachHangRepository = khachHangRepository;
		}

		[HttpGet("get-all")]
		public IActionResult GetAllKhachHang()
		{
			var khachHangs = _khachHangRepository.GetAllKhachHang();
			return Ok(khachHangs);
		}

		[HttpGet("get-by-id/{id}")]
		public IActionResult GetKhachHangById(int id)
		{
			var khachHang = _khachHangRepository.GetKhachHangById(id);
			if (khachHang == null)
			{
				return NotFound();
			}
			return Ok(khachHang);
		}

		[HttpPost("add-KhachHang")]
		public IActionResult AddKhachHang(AddKhachHangRequestDTO addKhachHangRequestDTO)
		{
			if (ModelState.IsValid)
			{
				var bookAdd = _khachHangRepository.AddKhachHang(addKhachHangRequestDTO);
				return Ok(bookAdd);
			}
			else return BadRequest(ModelState);
		}

		[HttpPut("update-KhachHang-by-id/{id}")]
		public IActionResult UpdateKhachHangById(int id, AddKhachHangRequestDTO addKhachHangRequestDTO)
		{
			var updateBook = _khachHangRepository.UpdateKhachHangById(id, addKhachHangRequestDTO);
			return Ok(updateBook);
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteKhachHangById(int id)
		{
			var deleteBook = _khachHangRepository.DeleteKhachHangById(id);
			return Ok(deleteBook);
		}
	}
}

