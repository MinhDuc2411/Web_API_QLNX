using DATA_DuAn.DTO.KhachHangDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using DATA_DuAn.DTO.HopDongDto;

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
            var response = await _httpClient.GetAsync("https://localhost:7154/api/HopDongThue");
            if (response.IsSuccessStatusCode)
            {
                var hopDong = await response.Content.ReadFromJsonAsync<List<HopDongThueDTO>>();
                return View();
            }
            else
            {
                // Handle error response
                return View("Error");
            }
        }

        // GET: HopDongThue/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HopDongThue/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HopDongThue/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HopDongThue/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HopDongThue/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HopDongThue/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HopDongThue/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
