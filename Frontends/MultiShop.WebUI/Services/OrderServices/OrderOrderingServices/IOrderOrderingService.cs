using MultiShop.DtoLayer.OrderDtos.OrderOrderingDto;

namespace MultiShop.WebUI.Services.OrderServices.OrderOrderingServices
{
    public interface IOrderOrderingService
    {
        Task<List<ResultOrderingByUserIDDto>> GetOrderingByUserID(string id);
    }
}
