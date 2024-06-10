    using DATA_DuAn.DTO.DanhMucXeDto;
using DATA_DuAn.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;

namespace View.Controllers
{
    public class DanhMucXeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public DanhMucXeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index([FromQuery] string? id)
        {
            var client = _httpClientFactory.CreateClient();
            List<DanhMucXeDTO> dTOs = new List<DanhMucXeDTO>();
            var data = await client.GetAsync($"https://localhost:7154/api/QuanLyDanhMucXe/GetAll?id="+id);
            data.EnsureSuccessStatusCode();
            dTOs.AddRange(await data.Content.ReadFromJsonAsync<IEnumerable<DanhMucXeDTO>>());           
            return View(dTOs);
        }
        
        // GET: DanhMucXe/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7154/api/QuanLyDanhMucXe/Get-By-Id?id="+id);
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
        // POST: DanhMucXe/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DanhMucXeDTO newXe)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.PostAsJsonAsync("https://localhost:7154/api/QuanLyDanhMucXe/add", newXe);
                response.EnsureSuccessStatusCode();

                return RedirectToAction(nameof(Index));
            }
            return View(newXe);
        }
        // GET: DanhMucXe/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var client = _httpClientFactory.CreateClient();
            DanhMucXeDTO vehicle = new DanhMucXeDTO();
            var response = await client.GetAsync("https://localhost:7154/api/QuanLyDanhMucXe/Get-By-Id?id=" + id);
            response.EnsureSuccessStatusCode();
            vehicle = await response.Content.ReadFromJsonAsync<DanhMucXeDTO>();
            return View(vehicle);
        } // POST: DanhMucXe/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCar(int id, AddDanhMucXeDTO updatedXe)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var httpReq = new HttpRequestMessage()
                {
                    Method = HttpMethod.Put,
                    RequestUri = new Uri("https://localhost:7154/api/QuanLyDanhMucXe/Update?id=" + id),
                    Content = new StringContent(JsonSerializer.Serialize(updatedXe),Encoding.UTF8,MediaTypeNames.Application.Json)
                };
                var httpRes = await client.SendAsync(httpReq);
                httpRes.EnsureSuccessStatusCode();
                var data = await httpRes.Content.ReadFromJsonAsync<AddDanhMucXeDTO>();
                if(data != null)
                {
                    return RedirectToAction("Index", "DanhMucXe");
                }
            }
            return View("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            try
            {
                var delXe = _httpClientFactory.CreateClient();
                var httpResponseMess = await delXe.DeleteAsync("https://localhost:7154/api/QuanLyDanhMucXe?id=" + id);
                httpResponseMess.EnsureSuccessStatusCode();
                return RedirectToAction("Index", "DanhMucXe");
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View("Index");
        }
    }
}