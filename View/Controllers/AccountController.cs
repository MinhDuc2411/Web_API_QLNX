using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Security.Claims;
using DATA_DuAn.DTO;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Net.Mime;

namespace View.Controllers
{
    public class AccountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AccountController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestDTO loginRequestDto)
        {
            try
            {
                var clt = _httpClientFactory.CreateClient();
                var jsonContent = new StringContent(JsonSerializer.Serialize(loginRequestDto), Encoding.UTF8,
                    "application/json");
                var response = await clt.PostAsync("https://localhost:7154/api/Acc/Login", jsonContent);
                if (response.IsSuccessStatusCode)
                {
                    // Đọc token từ phản hồi
                    var token = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Add token: {token}\n\n");
                    // Lưu token vào session
                    HttpContext.Session.SetString("Jwt", token);

                    // Chuyển hướng đến trang chính sau khi đăng nhập thành công
                    return RedirectToAction("Index", "DanhMucXe");
                }
                else
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    ModelState.AddModelError(string.Empty, "Invalid login attempt: " + errorMessage);
                }
            }
            catch
            {
                return RedirectToAction("Login", "Account");
            }
            return RedirectToAction("Login", "Account");
        }
        public IActionResult Logout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LogoutSuccess()
        {
            try
            {
                // Xóa token khỏi session
                HttpContext.Session.Remove("Jwt");
                // Chuyển hướng đến trang đăng nhập sau khi đăng xuất
                return RedirectToAction("Login", "Account");
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
        public IActionResult Register()
        {
            var registerRequest = new RegisterRequestDTO();
            registerRequest.Roles = new string[] { "Read", "Write" };
            ViewBag.Roles = registerRequest.Roles;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequestDTO registerRequestDto)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var httpReq = new HttpRequestMessage()
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri("https://localhost:7154/api/Acc/Register"),
                    Content = new StringContent(JsonSerializer.Serialize(registerRequestDto), Encoding.UTF8,
                        MediaTypeNames.Application.Json)
                };
                var httpRes = await client.SendAsync(httpReq);

                return RedirectToAction("Login", "Account");
            }
            catch
            {
                return RedirectToAction("Register", "Account");
            }

        }
    }
}
