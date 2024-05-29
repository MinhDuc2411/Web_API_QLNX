using Microsoft.AspNetCore.Mvc;
using DATA_DuAn.Data;
using DuAnWeb_QLNX.Repository.HopDongThueRepository;
using DATA_DuAn.DTO.HopDongDto;
namespace DuAnWeb_QLNX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HopDongThue : ControllerBase
    {
        private readonly IHopDongThueRepository _repository;

        public HopDongThue(IHopDongThueRepository repository)
        {
            _repository = repository;
        }

        // GET: api/HopDongThue
        [HttpGet]
        public ActionResult<IEnumerable<HopDongThueDTO>> GetHopDongThues()
        {
            var hopDongThues = _repository.GetHopDong();
            return Ok(hopDongThues);
        }

        // GET: api/HopDongThue/5
        [HttpGet("{id}")]
        public ActionResult<HopDongThueDTO> GetHopDongThue(int id)
        {
            var hopDongThue = _repository.GetHopDong(id);
            if (hopDongThue == null)
            {
                return NotFound();
            }
            return Ok(hopDongThue);
        }

        // GET: api/HopDongThue/khachhang/5
        [HttpGet("khachhang/{id}")]
        public ActionResult<IEnumerable<HopDongThueDTO>> GetHopDongByKhachHang(int id)
        {
            var hopDongThues = _repository.GetMaKH(id);
            return Ok(hopDongThues);
        }

        // POST: api/HopDongThue
        [HttpPost]
        public ActionResult<AddHopDongDTO> PostHopDongThue(AddHopDongDTO addHopDong)
        {
            var createdHopDong = _repository.AddHopDong(addHopDong);
            return CreatedAtAction(nameof(GetHopDongThue), new { id = createdHopDong.MaKH }, createdHopDong);
        }

        // PUT: api/HopDongThue/5
        [HttpPut("{id}")]
        public IActionResult PutHopDongThue(int id, AddHopDongDTO addHopDong)
        {
            if (id != addHopDong.MaKH)
            {
                return BadRequest();
            }

            var updatedHopDong = _repository.PutHopDong(addHopDong, id);
            if (updatedHopDong == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/HopDongThue/5
        [HttpDelete("{id}")]
        public IActionResult DeleteHopDongThue(int id)
        {
            var hopDongThue = _repository.Delete(id);
            if (hopDongThue == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}

    
