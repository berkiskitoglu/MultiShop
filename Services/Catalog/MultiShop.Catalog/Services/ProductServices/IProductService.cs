using MultiShop.Catalog.Dtos.ProductDtos;

namespace MultiShop.Catalog.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
        Task DeleteProductAsync(string id);
        Task<GetByIDProductDto> GetByIDProductAsync(string id);
        Task<List<ResultProductsWithCategoryDto>> GetProductsWithCategroyAsync();
        Task<List<ResultProductsWithCategoryDto>> GetProductsWithCategroyByCategoryIDAsync(string categoryID);
    }
}
