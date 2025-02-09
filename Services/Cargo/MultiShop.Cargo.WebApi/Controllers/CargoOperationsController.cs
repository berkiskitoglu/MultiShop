using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoOperationDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationsController : ControllerBase
    {
        private readonly ICargoOpertaionService _cargoOpertaionService;

        public CargoOperationsController(ICargoOpertaionService cargoOpertaionService)
        {
            _cargoOpertaionService = cargoOpertaionService;
        }

        [HttpGet]
        public IActionResult CargoCompanyList()
        {
            var values = _cargoOpertaionService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCargoOperation(CreateCargoOperationDto createCargoOperation)
        {
            CargoOperation cargoOperation = new CargoOperation()
            {
                Barcode = createCargoOperation.Barcode,
                Description = createCargoOperation.Description,
                OperationDate = createCargoOperation.OperationDate
            };
            _cargoOpertaionService.TInsert(cargoOperation);
            return Ok("Kargo İşlemi Başarıyla Oluşturuldu");
        }
        [HttpDelete]
        public IActionResult RemoveCargoOperation(int id)
        {
            _cargoOpertaionService.TDelete(id);
            return Ok("Kargo İşlemi Başarıyla Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetCargoOperationByID(int id)
        {
            var values = _cargoOpertaionService.TGetByID(id);
            return Ok(values);
        }
        [HttpPut]
        public IActionResult UpdateCargoOperation(UpdateCargoOperationDto updateCargoOperationDto)
        {
            CargoOperation cargoOperation = new CargoOperation()
            {
                Barcode = updateCargoOperationDto.Barcode,
                CargoOperationID = updateCargoOperationDto.CargoOperationID,
                Description = updateCargoOperationDto.Description,
                OperationDate = updateCargoOperationDto.OperationDate
            };
            _cargoOpertaionService.TUpdate(cargoOperation);
            return Ok("Kargo İşlemi Başarıyla Güncellendi");
        }
    }
}
