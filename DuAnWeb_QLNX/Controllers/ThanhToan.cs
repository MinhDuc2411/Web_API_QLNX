using DATA_DuAn.DTO.ThanhToanDTO;
using DuAnWeb_QLNX.Repository.ThanhToanRepository;
using Microsoft.AspNetCore.Mvc;

namespace DuAnWeb_QLNX.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ThanhToan: ControllerBase
    {
		private readonly IThanhToanRepository _thanhToanRepository;

		public ThanhToan(IThanhToanRepository thanhToanRepository)
		{
			_thanhToanRepository = thanhToanRepository;
		}

		[HttpGet("get-all")]
		public IActionResult GetAllThanhToan()
		{
			var thanhToanList = _thanhToanRepository.GetAllThanhToan();
			return Ok(thanhToanList);
		}

		[HttpGet("get-by-id/{id}")]
		public IActionResult GetThanhToanById(int id)
		{
			try
			{
				var result = _thanhToanRepository.GetThanhToanById(id);
				if (result == null)
				{
					return NotFound();
				}
				return Ok(result);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpPost("add")]
		public IActionResult AddThanhToan(AddThanhToanRequestDTO addThanhToanRequestDTO)
		{
			try
			{
				var result = _thanhToanRepository.AddThanhToan(addThanhToanRequestDTO);
				return Ok(result);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpPut("update-by-id/{id}")]
		public IActionResult UpdateThanhToanById(int id, AddThanhToanRequestDTO addThanhToanRequestDTO)
		{
			try
			{
				var result = _thanhToanRepository.UpdateThanhToanById(id, addThanhToanRequestDTO);
				if (result == null)
				{
					return NotFound();
				}
				return Ok(result);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpDelete("delete-by-id/{id}")]
		public IActionResult DeleteThanhToanById(int id)
		{
			try
			{
				var result = _thanhToanRepository.DeleteThanhToanById(id);
				if (result == null)
				{
					return NotFound();
				}
				return Ok(result);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}
	}
}

