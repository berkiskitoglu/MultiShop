using System.Security.Claims;
using MultiShop.WebUI.Services.Interfaces;

namespace MultiShop.WebUI.Services.Concrete
{
    public class LoginService : ILoginService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public LoginService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }


        public string GetUserID => _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);


    }
}
