using MultiShop.DtoLayer.OrderDtos.OrderOrderingDto;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.OrderServices.OrderOrderingServices
{
    public class OrderOrderingService : IOrderOrderingService
    {

        private readonly HttpClient _httpClient;
        public OrderOrderingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
     
        public async Task<List<ResultOrderingByUserIDDto>> GetOrderingByUserID(string id)
        {
            //$"products/ProductListWithCategoryByCategoryId/{CategoryId}"
            var responseMessage = await _httpClient.GetAsync($"orderings/GetOrderingByUserID/{id}");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultOrderingByUserIDDto>>(jsonData);
            return values;
        }
    }
}
