using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.SpecialOfferDtos;
using MultiShop.Catalog.Services.SpecialOfferServices;

namespace MultiShop.Catalog.Controllers
{
	[Authorize]

	[Route("api/[controller]")]
    [ApiController]
    public class SpecialOffersController : ControllerBase
    {

        private readonly ISpecialOfferService _specialOffersService;

        public SpecialOffersController(ISpecialOfferService specialOffersService)
        {
            _specialOffersService = specialOffersService;
        }

        [HttpGet]
        public async Task<IActionResult> SpecialOfferList()
        {
            var values = await _specialOffersService.GetAllSpecialOfferAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpecialOfferByID(string id)
        {
            var values = await _specialOffersService.GetByIDSpecialOfferAsync(id);
            return Ok(values);

        }
        [HttpPost]
        public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto)
        {
            await _specialOffersService.CreateSpecialOfferAsync(createSpecialOfferDto);
            return Ok("Özel Teklif Başarıyla Eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteSpecialOffer(string id)
        {
            await _specialOffersService.DeleteSpecialOfferAsync(id);
            return Ok("Özel Teklif Başarıyla Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            await _specialOffersService.UpdateSpecialOfferAsync(updateSpecialOfferDto);
            return Ok("Özel Teklif Başarılı Bir Şekilde Güncellendi");
        }
    }
}

