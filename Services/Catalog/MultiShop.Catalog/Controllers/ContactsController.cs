using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ContactDtos;
using MultiShop.Catalog.Services.ContactServices;

namespace MultiShop.Catalog.Controllers
{
	[Authorize]

	[Route("api/[controller]")]
    [ApiController]
    public class ContactsController : Controller
    {
        private readonly IContactService _categoryService;

        public ContactsController(IContactService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> ContactList()
        {
            var values = await _categoryService.GetAllContactAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactByID(string id)
        {
            var values = await _categoryService.GetByIDContactAsync(id);
            return Ok(values);

        }
        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
        {
            await _categoryService.CreateContactAsync(createContactDto);
            return Ok("Mesaj Başarıyla Eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteContact(string id)
        {
            await _categoryService.DeleteContactAsync(id);
            return Ok("Mesaj Başarıyla Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateContact(UpdateContactDto updateContactDto)
        {
            await _categoryService.UpdateContactAsync(updateContactDto);
            return Ok("Mesaj Başarılı Bir Şekilde Güncellendi");
        }
    }
}
