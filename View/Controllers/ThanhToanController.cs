using DATA_DuAn.DTO.HopDongDto;
using DATA_DuAn.DTO.NhanVienDto;
using DATA_DuAn.DTO.ThanhToanDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Text;
using System.Text.Json;

namespace View.Controllers
{
    public class ThanhToanController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpClientFactory _httpClientFactory;
        public ThanhToanController(HttpClient httpClient, IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClient;
            _httpClientFactory = httpClientFactory;
        }
        // GET: ThanhToan
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("https://localhost:7154/api/ThanhToan/get-all");
            if (response.IsSuccessStatusCode)
            {
                var thanhtoan = await response.Content.ReadFromJsonAsync<List<ThanhToanDTO>>();
                return View(thanhtoan);
            }
            else
            {
                // Handle error response
                return View("Error");
            }
        }

        // GET: ThanhToanController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7154/api/ThanhToan/get-by-id/{id}");
            if (response.IsSuccessStatusCode)
            {
                var thanhtoan = await response.Content.ReadFromJsonAsync<ThanhToanDTO>();
                return View(thanhtoan);
            }
            else
            {
                // Handle error response
                return View("Error");
            }
        }


        // GET: ThanhToanController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ThanhToanController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ThanhToanDTO addthanhtoan)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.PostAsJsonAsync("https://localhost:7154/api/ThanhToan/add", addthanhtoan);
                response.EnsureSuccessStatusCode();

                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: ThanhToanController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var client = _httpClientFactory.CreateClient();
            ThanhToanDTO vehicle = new ThanhToanDTO();
            var response = await client.GetAsync($"https://localhost:7154/api/ThanhToan/get-by-id/{id}");
            response.EnsureSuccessStatusCode();
            vehicle = await response.Content.ReadFromJsonAsync<ThanhToanDTO>();
            return View(vehicle);
        }

        // POST: ThanhToanController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AddThanhToanRequestDTO updatedthanhtoan)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var httpReq = new HttpRequestMessage()
                {
                    Method = HttpMethod.Put,
                    RequestUri = new Uri($"https://localhost:7154/api/ThanhToan/update-by-id/{id}"),
                    Content = new StringContent(JsonSerializer.Serialize(updatedthanhtoan), Encoding.UTF8, MediaTypeNames.Application.Json)
                };
                var httpRes = await client.SendAsync(httpReq);
                httpRes.EnsureSuccessStatusCode();
                var data = await httpRes.Content.ReadFromJsonAsync<AddThanhToanRequestDTO>();
                if (data != null)
                {
                    return RedirectToAction("Index", "ThanhToan");
                }
            }
            return View("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var delXe = _httpClientFactory.CreateClient();
                var httpResponseMess = await delXe.DeleteAsync($"https://localhost:7154/api/ThanhToan/delete-by-id/{id}");
                httpResponseMess.EnsureSuccessStatusCode();
                return RedirectToAction("Index", "ThanhToan");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View("Index");
        }
    }
}
