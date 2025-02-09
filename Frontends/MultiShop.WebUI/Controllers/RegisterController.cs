using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.IdentityDtos.RegisterDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Controllers
{
    public class RegisterController : Controller
    {
		private readonly IHttpClientFactory _httpClientFactory;

		public RegisterController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		[HttpGet]
		public IActionResult Index()
		{

			ViewBag.v1 = "Anasayfa";
			ViewBag.v2 = "Kategoriler";
			ViewBag.v3 = "Kategori Ekleme Sayfası";
			ViewBag.v0 = "Kategori İşlemleri";

			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index(CreateRegisterDto createRegisterDto)
		{
			if (createRegisterDto.Password == createRegisterDto.ConfirmPassword)
			{
				var client = _httpClientFactory.CreateClient();
				var jsonData = JsonConvert.SerializeObject(createRegisterDto);
				StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
				var responseMessage = await client.PostAsync("http://localhost:5001/api/Registers", stringContent);
				if (responseMessage.IsSuccessStatusCode)
				{
					return RedirectToAction("Index", "Login");
				}
			}
			return View();
			
		}
	}
}
