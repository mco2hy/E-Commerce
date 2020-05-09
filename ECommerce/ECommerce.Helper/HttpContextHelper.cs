namespace ECommerce.Helper
{
    public class HttpContextHelper
    {
        private static Microsoft.AspNetCore.Http.IHttpContextAccessor _httpContextAccessor;

        public static Microsoft.AspNetCore.Http.HttpContext Current => _httpContextAccessor.HttpContext;

        public static void Configure(Microsoft.AspNetCore.Http.IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
    }
}