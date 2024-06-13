using DATA_DuAn.DTO.KhachHangDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using DATA_DuAn.DTO.HopDongDto;
using DATA_DuAn.DTO.NhanVienDto;

namespace View.Controllers
{
    public class HopDongThue : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpClientFactory _httpClientFactory;
        public HopDongThue(HttpClient httpClient, IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClient;
            _httpClientFactory = httpClientFactory;
        }
        // GET: HopDongThue
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("https://localhost:7154/api/HopDongThue/get-all");
            if (response.IsSuccessStatusCode)
            {
                var hopDong = await response.Content.ReadFromJsonAsync<List<HopDongThueDTO>>();
                return View(hopDong);
            }
            else
            {
                // Handle error response
                return View("Error");
            }
        }

        // GET: HopDongThue/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7154/api/HopDongThue/get-by-id/{id}");
            if (response.IsSuccessStatusCode)
            {
                var hopdong = await response.Content.ReadFromJsonAsync<HopDongThueDTO>();
                return View(hopdong);
            }
            else
            {
                // Handle error response
                return View("Error");
            }
        }


        // GET: HopDongThue/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HopDongThue/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HopDongThueDTO addhopdong)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.PostAsJsonAsync("https://localhost:7154/api/HopDongThue/add", addhopdong);
                response.EnsureSuccessStatusCode();

                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var delXe = _httpClientFactory.CreateClient();
                var httpResponseMess = await delXe.DeleteAsync("https://localhost:7154/api/HopDongThue/delete?id=" + id);
                httpResponseMess.EnsureSuccessStatusCode();
                return RedirectToAction("Index", "HopDongThue");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View("Index");
        }
    }
}
