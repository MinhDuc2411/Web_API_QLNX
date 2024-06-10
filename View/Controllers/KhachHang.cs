using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc;
using DATA_DuAn.DTO.KhachHangDTO;
using DATA_DuAn.Models;
using System.Text.Json;
using System.Text;
using System.Net.Mime;

namespace DuAnWeb_QLNX.Controllers
{
    public class KhachHangController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpClientFactory _httpClientFactory;

        public KhachHangController(HttpClient httpClient, IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClient;
            _httpClientFactory = httpClientFactory;
        }

        // GET: KhachHang
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("https://localhost:7154/api/KhachHang/get-all");
            if (response.IsSuccessStatusCode)
            {
                var khachHangs = await response.Content.ReadFromJsonAsync<List<KhachHangDTO>>();
                return View(khachHangs);
            }
            else
            {
                // Handle error response
                return View("Error");
            }
        }

        // GET: KhachHang/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7154/api/KhachHang/get-by-id/{id}");
            if (response.IsSuccessStatusCode)
            {
                var khachHang = await response.Content.ReadFromJsonAsync<KhachHangDTO>();
                return View(khachHang);
            }
            else
            {
                // Handle error response
                return View("Error");
            }
        }

        // GET: DanhMucXe/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7154/api/KhachHang/get-by-id?id"+id);
            response.EnsureSuccessStatusCode();
            var vehicle = await response.Content.ReadFromJsonAsync<KhachHangDTO>();
            return View(vehicle);
        }

        // POST: DanhMucXe/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, KhachHangDTO updatedKhachHang)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var httpReq = new HttpRequestMessage()
                {
                    Method = HttpMethod.Put,
                    RequestUri = new Uri("https://localhost:7154/api/KhachHang/update-KhachHang-by-id?id"+id),
                    Content = new StringContent(JsonSerializer.Serialize(updatedKhachHang), Encoding.UTF8, MediaTypeNames.Application.Json)
                };

                var httpRes = await client.SendAsync(httpReq);
                httpRes.EnsureSuccessStatusCode();

                return RedirectToAction("Index", "KhachHang");
            }

            return View(updatedKhachHang);
        }


        // GET: KhachHang/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7154/api/KhachHang/get-by-id/{id}");
            if (response.IsSuccessStatusCode)
            {
                var khachHang = await response.Content.ReadFromJsonAsync<KhachHangDTO>();
                return View(khachHang);
            }
            else
            {
                // Handle error response
                return View("Error");
            }
        }

        // POST: KhachHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:7154/api/KhachHang/delete/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                // Handle error response
                return View("Error");
            }
        }
    }
}
