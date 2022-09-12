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

        /// <summary>
        /// Validates the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>object</returns>
        [HttpPost("ValidateUser")]
        public IActionResult Validate([FromBody]User user)
        {
            string result = string.Empty;
           
            try
            {
                User validate = _authorTokenService.ValidateUser(user.UserName, user.Password, user.UserType);
                if (validate != null)
                {
                    result = BuildToken(_configuration["Jwt:Key"],
                                            _configuration["Jwt:Issuer"],
                                            new[]
                                            {
                                            _configuration["Jwt:Aud1"],
                                            _configuration["Jwt:Aud2"],
                                            _configuration["Jwt:Aud3"]
                                            },
                                            validate.UserName,
                                            validate.UserType,
                                            validate.UserId);
                    var token = new TokenModel
                    {
                        Token = result,
                        IsAuthenticated = true,
                        Message = "Login sucessfull",
                        StatusCode = 1
                    };
                    return Ok(token);
                }
                else
                {
                    return Ok(new TokenModel
                    {
                        Token = result,
                        IsAuthenticated = false,
                        Message = "Not a valid user",
                        StatusCode = 0
                    });
                }
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpPost("CheckExistingUser")]
        public IActionResult CheckExistingUser([FromBody] User user)
        {
            try
            {
                User result = _authorTokenService.CheckExistingUser(user.UserName, user.UserType);

                if (result != null)
                {
                    return Ok(new TokenModel
                    {
                        Message = "User already exist",
                        StatusCode = 0
                    });
                } 
                else
                {
                    return Ok(new TokenModel
                    {
                        StatusCode = 1
                    });
                }
                    
            }
            catch(Exception ex)
            {
                    return BadRequest(ex.Message);
            }
        }

        private string BuildToken(string key, string issuer, IEnumerable<string> audience, string userName, string userType, long userId)
        {
            var claims = new List<Claim>
            {
                new Claim("userName", !string.IsNullOrWhiteSpace(userName) ? userName : string.Empty),
                new Claim("userType",!string.IsNullOrWhiteSpace(userType) ? userType : string.Empty ),
                new Claim("userId", !string.IsNullOrWhiteSpace(userId.ToString()) ? userId.ToString() : string.Empty),
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