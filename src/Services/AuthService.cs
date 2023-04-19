using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AuthenticationPlugin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RestApiSample.Interfaces;
using RestApiSample.Models;


namespace RestApiSample.Services
{

    public class AuthCustomService
    {

        private readonly UserService _userService;
        private IConfiguration _configuration;



        public AuthCustomService(UserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        public Object? Login([FromBody] ILogin user)
        {
            var getUser = _userService.getUserByEmail(user.Email);

            if (getUser is null)
            {
                return null;
            }

            if (!SecurePasswordHasherHelper.Verify(user.Password, getUser.Password))
            {
                return null;
            }

            var jwt = createToken(getUser);

            return new { token = jwt };
        }


        private string createToken(User user)
        {
            var claims = new Claim[]{
            new Claim("id",user.Id.ToString()),
             new Claim("role",user.Role),
            new Claim(JwtRegisteredClaimNames.Email,user.Email),
            new Claim(JwtRegisteredClaimNames.Iss,"localhost.com"),
            new Claim(JwtRegisteredClaimNames.Aud,"localhost.com"),
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Tokens:Key").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(claims: claims, expires: DateTime.Now.AddDays(1), signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }


    }




}