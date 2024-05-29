    using DATA_DuAn.DTO.DanhMucXeDto;
    using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;

namespace View.Controllers
{
    public class DanhMucXeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public DanhMucXeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            List<DanhMucXeDTO> dTOs = new List<DanhMucXeDTO>();
            var data = await client.GetAsync($"https://localhost:7154/api/QuanLyDanhMucXe/GetAll?");
            data.EnsureSuccessStatusCode();
            dTOs.AddRange(await data.Content.ReadFromJsonAsync<IEnumerable<DanhMucXeDTO>>());           
            return View(dTOs);
        }

        // GET: DanhMucXe/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7154/api/QuanLyDanhMucXe/add");
            response.EnsureSuccessStatusCode();

            var vehicle = await response.Content.ReadFromJsonAsync<DanhMucXeDTO>();
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // GET: DanhMucXe/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost, ActionName("DeleteDanhMucXe")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7154/api/QuanLyDanhMucXe");
            response.EnsureSuccessStatusCode();

            return RedirectToAction(nameof(Index));
        }
    }
}