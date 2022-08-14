using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TokenAuthentication.Models;
using TokenAuthentication.Services;

namespace TokenAuthentication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TokenAuthenticationController : ControllerBase
    {
        private readonly IAuthorTokenService _authorTokenService;
        private readonly IConfiguration _configuration;
        public TokenAuthenticationController(IAuthorTokenService authorTokenService, IConfiguration configuration)
        {
            _authorTokenService = authorTokenService;
            this._configuration = configuration;
        }

        [HttpPost]
        public ActionResult<string> Validate([FromBody]User user)
        {
            string result = string.Empty;
            if (_authorTokenService.ValidateUser(user.UserName, user.Password))
            {
                result = BuildToken(_configuration["Jwt:Key"],
                                        _configuration["Jwt:Issuer"],
                                        new[]
                                        {
                                            _configuration["Jwt:Aud1"],
                                            _configuration["Jwt:Aud2"]
                                        },
                                        user.UserName);

            }
            else
            {
                result = "Not authorised";
            }

            return Ok(result);
        }

        public string BuildToken(string key, string issuer, IEnumerable<string> audience, string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userName)
            };

            claims.AddRange(audience.Select(aud => new Claim(JwtRegisteredClaimNames.Aud, aud)));

            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new JwtSecurityToken(issuer, issuer, claims, notBefore: DateTime.Now, expires: DateTime.Now.Add(new TimeSpan(20, 30, 0)),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }

    }
}