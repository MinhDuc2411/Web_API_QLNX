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
        public async Task< IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            List<DanhMucXeDTO> dTOs = new List<DanhMucXeDTO>();
            var data = await client.GetAsync($"https://localhost:7154/api/QuanLyDanhMucXe/GetAll?Bienso");
            data.EnsureSuccessStatusCode();
            dTOs.AddRange(await data.Content.ReadFromJsonAsync<IEnumerable<DanhMucXeDTO>>());
            return View(dTOs);
        }
    }
}
