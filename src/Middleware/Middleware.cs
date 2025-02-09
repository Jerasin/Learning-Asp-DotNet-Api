using Microsoft.AspNetCore.Authorization;
using RestApiSample.src.Models;

namespace RestApiSample.src.Middleware
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public CustomAuthorizeAttribute(Roles roleEnum)
        {
            Roles = roleEnum.ToString().Replace(" ", string.Empty);
            Console.WriteLine("roleEnum = {0}", roleEnum);
            Console.WriteLine("Roles = {0}", Roles);
        }
    }

}