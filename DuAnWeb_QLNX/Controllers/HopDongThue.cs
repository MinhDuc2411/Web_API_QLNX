using Microsoft.AspNetCore.Mvc;
using DuAnWeb_QLNX.Repository.HopDongThueRepository;
using DATA_DuAn.DTO.HopDongDto;
using System.Collections.Generic;

namespace DuAnWeb_QLNX.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HopDongThueController : ControllerBase
    {
        private readonly IHopDongThueRepository _hopDongThueRepository;

        public HopDongThueController(IHopDongThueRepository hopDongThueRepository)
        {
            _hopDongThueRepository = hopDongThueRepository;
        }

        [HttpGet("get-all")]
        public IActionResult GetAllHopDong()
        {
            var hopDongs = _hopDongThueRepository.GetHopDong();
            return Ok(hopDongs);
        }

        [HttpGet("get-by-id/{id}")]
        public IActionResult GetHopDongById(int id)
        {
            var hopDong = _hopDongThueRepository.GetHopDong(id);
            if (hopDong == null)
            {
                return NotFound();
            }
            return Ok(hopDong);
        }

        [HttpPost("add")]
        public IActionResult AddHopDong(AddHopDongDTO addHopDongDTO)
        {
            if (ModelState.IsValid)
            {
                var addedHopDong = _hopDongThueRepository.AddHopDong(addHopDongDTO);
                return Ok(addedHopDong);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateHopDong(int id, AddHopDongDTO addHopDongDTO)
        {
            var updatedHopDong = _hopDongThueRepository.PutHopDong(addHopDongDTO, id);
            if (updatedHopDong == null)
            {
                return NotFound();
            }
            return Ok(updatedHopDong);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteHopDong(int id)
        {
            var deletedHopDong = _hopDongThueRepository.Delete(id);
            if (deletedHopDong == null)
            {
                return NotFound();
            }
            return Ok(deletedHopDong);
        }
    }
}
