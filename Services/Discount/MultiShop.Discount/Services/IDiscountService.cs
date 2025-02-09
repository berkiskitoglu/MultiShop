using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    public interface IDiscountService
    {
        Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponAsync();
        Task CreateDiscountCouponAsync(CreateDiscountCouponDto createDiscountCouponDto);
        Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateDiscountCouponDto);
        Task DeleteDiscountCouponAsync(int id);
        Task<GetByIDDiscountCouponDto> GetByIDDiscountCouponAsync(int id);
        Task<ResultDiscountCouponDto> GetCodeDetailByCodeAsync(string code);
        int GetDiscountCouponCountRate(string code);
        Task<int> GetDiscountCouponCount();
    }
}
