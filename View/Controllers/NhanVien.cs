using DATA_DuAn.DTO.KhachHangDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using DATA_DuAn.DTO.NhanVienDto;
using DATA_DuAn.DTO.DanhMucXeDto;
using System.Net.Mime;
using System.Text;
using System.Text.Json;

namespace View.Controllers
{
    public class NhanVien : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpClientFactory _httpClientFactory;

        public NhanVien(HttpClient httpClient, IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClient;
            _httpClientFactory = httpClientFactory;
        }
        // GET: NhanVien
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("https://localhost:7154/api/NhanVien/get-all");
            if (response.IsSuccessStatusCode)
            {
                var NhanVien = await response.Content.ReadFromJsonAsync<List<NhanVienDTO>>();
                return View(NhanVien);
            }
            else
            {
                // Handle error response
                return View("Error");
            }
        }

        // GET: NhanVien/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7154/api/NhanVien/get-by-id/{id}");
            if (response.IsSuccessStatusCode)
            {
                var nhanVien = await response.Content.ReadFromJsonAsync<NhanVienDTO>();
                return View(nhanVien);
            }
            else
            {
                // Handle error response
                return View("Error");
            }
        }

        // GET: NhanVien/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NhanVien/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NhanVienDTO addnhanvien)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.PostAsJsonAsync("https://localhost:7154/api/NhanVien/add-NhanVien", addnhanvien);
                response.EnsureSuccessStatusCode();

                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: NhanVien/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var client = _httpClientFactory.CreateClient();
            NhanVienDTO vehicle = new NhanVienDTO();
            var response = await client.GetAsync($"https://localhost:7154/api/NhanVien/get-by-id/{id}");
            response.EnsureSuccessStatusCode();
            vehicle = await response.Content.ReadFromJsonAsync<NhanVienDTO>();
            return View(vehicle);
        } // POST: DanhMucXe/Edit/5

        // POST: NhanVien/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AddNhanVienRequestDTO updatednhanvien)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var httpReq = new HttpRequestMessage()
                {
                    Method = HttpMethod.Put,
                    RequestUri = new Uri("https://localhost:7154/api/NhanVien/update-NhanVien?id=" + id),
                    Content = new StringContent(JsonSerializer.Serialize(updatednhanvien), Encoding.UTF8, MediaTypeNames.Application.Json)
                };
                var httpRes = await client.SendAsync(httpReq);
                httpRes.EnsureSuccessStatusCode();
                var data = await httpRes.Content.ReadFromJsonAsync<AddNhanVienRequestDTO>();
                if (data != null)
                {
                    return RedirectToAction("Index", "NhanVien");
                }
            }
            return View("Index");
        }

        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var delXe = _httpClientFactory.CreateClient();
                var httpResponseMess = await delXe.DeleteAsync("https://localhost:7154/api/NhanVien/Detele-NhanVien?id=" + id);
                httpResponseMess.EnsureSuccessStatusCode();
                return RedirectToAction("Index", "NhanVien");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View("Index");
        }
    }
}
