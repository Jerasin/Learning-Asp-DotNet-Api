using Microsoft.AspNetCore.Mvc;

namespace RestApiSample.Interfaces
{

    public class ILogin
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public interface IAuthService
    {
        public IActionResult test([FromBody] ILogin user);

        public Object? createToken();

    }

}




