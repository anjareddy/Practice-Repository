using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Practice.CityInfo.API.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        public class AuthenticationRequestBody
        {
            public string UserName { get; set; }
            public string Password { get; set; }
        }

        public class CityInfoUser
        {
            public int UserId { get; set; }
            public string UserName { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string City { get; set; }

            public CityInfoUser(int _userId, 
                string _userName, string _firstName, 
                string _lastName, string _city)
            {
                UserId = _userId;
                UserName = _userName;
                FirstName = _firstName;
                LastName = _lastName;
                City = _city;
            }
        }

        public readonly IConfiguration _configuration;
        public AuthenticationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("authenticate")]
        public ActionResult<string> Authenticate(AuthenticationRequestBody authenticationRequestBody)
        {
            var user = ValidateUserCredentials(authenticationRequestBody.UserName, authenticationRequestBody.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            /// Creating token
            var securityKey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"]));
            var signinCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claimsForToken = new List<Claim>
            {
                new Claim("sub", user.UserId.ToString()),
                new Claim("given_name", user.FirstName),
                new Claim("family_name", user.LastName),
                new Claim("city", user.City)
            };

            var jwtSecurityToken = new JwtSecurityToken(
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claimsForToken,
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(1),
                signinCredentials
                );

            var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            return Ok(token);
        }

        private CityInfoUser? ValidateUserCredentials(string userName, string password)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                return null;
            }

            return new CityInfoUser(1, userName ?? "",
                "Anja Reddy", "Gaddam", "Cleveland");
        }
    }
}
